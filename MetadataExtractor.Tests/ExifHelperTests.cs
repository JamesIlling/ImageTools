namespace MetadataExtractor.Tests
{
    using System;
    using System.Linq;
    using System.Text;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ExifHelperTests
    {
        [TestCase(ushort.MaxValue)]
        [TestCase(ushort.MinValue)]
        [TestCase((ushort) 0x1010)]
        public void GetShortReturnsExpectedValue(ushort value)
        {
            var property = new ExifProperty {Id = 0, Length = 1, Type = 3, Value = BitConverter.GetBytes(value)};

            var extracted = ExifHelper.GetShort(property);
            extracted.Should().BeOfType(typeof(uint));
            extracted.Should().Be(value);
        }

        [TestCase(short.MaxValue)]
        [TestCase(short.MinValue)]
        [TestCase((short) 0x1010)]
        public void GetSignedShortReturnsExpectedValue(short value)
        {
            var property = new ExifProperty {Id = 0, Length = 1, Type = 3, Value = BitConverter.GetBytes(value)};

            var extracted = ExifHelper.GetSignedShort(property);
            extracted.Should().BeOfType(typeof(int));
            extracted.Should().Be(value);
        }


        [TestCase(uint.MaxValue)]
        [TestCase(uint.MinValue)]
        [TestCase(0x10101010u)]
        [TestCase(0x00001111u)]
        [TestCase(0x11110000u)]
        public void GetLongReturnsExpectedValue(uint value)
        {
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = BitConverter.GetBytes(value)};

            var extracted = ExifHelper.GetLong(property);
            extracted.Should().BeOfType(typeof(uint));
            extracted.Should().Be(value);
        }

        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(0x10101010)]
        [TestCase(0x00001111)]
        [TestCase(0x11110000)]
        public void GetSignedLongReturnsExpectedValue(int value)
        {
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = BitConverter.GetBytes(value)};

            var extracted = ExifHelper.GetSignedLong(property);
            extracted.Should().BeOfType(typeof(int));
            extracted.Should().Be(value);
        }

        [TestCase(1u, 4u, 0.25)]
        [TestCase(4u, 1u, 4)]
        [TestCase(1u, 100u, 0.01)]
        [TestCase(uint.MaxValue, uint.MaxValue, 1)]
        public void GetRationalReturnsExpectedValue(uint nominator, uint denominator, decimal fraction)
        {
            var value = ExifTypeHelper.CreateRational(nominator, denominator);
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = value};

            var extracted = ExifHelper.GetRational(property);
            extracted.Should().BeOfType(typeof(decimal));
            extracted.Should().Be(fraction);
        }

        [TestCase(1u, 4u, 0.25)]
        [TestCase(4u, 1u, 4)]
        [TestCase(1u, 100u, 0.01)]
        [TestCase(uint.MaxValue, uint.MaxValue, 1)]
        public void GetRationalWithIndexReturnsExpectedValue(uint nominator, uint denominator, decimal fraction)
        {
            var value =
                ExifTypeHelper.CreateRational(1,1).Concat(ExifTypeHelper.CreateRational(nominator,denominator)).ToArray();
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = value};

            var extracted = ExifHelper.GetRational(property, 1);
            extracted.Should().BeOfType(typeof(decimal));
            extracted.Should().Be(fraction);
        }

        [TestCase(1, 4, 0.25)]
        [TestCase(4, 1, 4)]
        [TestCase(-1, 100, -0.01)]
        [TestCase(-1, -100, 0.01)]
        [TestCase(int.MaxValue, int.MaxValue, 1)]
        [TestCase(int.MinValue, int.MinValue, 1)]
        public void GetSignedRationalReturnsExpectedValue(int nominator, int denominator, decimal fraction)
        {
            var value = ExifTypeHelper.CreateSignedRational(nominator, denominator);
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = value};

            var extracted = ExifHelper.GetSignedRational(property);
            extracted.Should().BeOfType(typeof(decimal));
            extracted.Should().Be(fraction);
        }

        [TestCase(byte.MaxValue)]
        [TestCase(byte.MinValue)]
        [TestCase(0xFE)]
        [TestCase(0xCC)]
        [TestCase(0x01)]
        public void GetByteReturnsExpectedValue(byte value)
        {
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = BitConverter.GetBytes(value)};

            var extracted = ExifHelper.GetByte(property);
            extracted.Should().BeOfType(typeof(byte));
            extracted.Should().Be(value);
        }

        [Test]
        public void GetRationalThrowsErrorOnZeroDenominator()
        {
            var value = ExifTypeHelper.CreateRational(0, 0);
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = value};
            Assert.Throws<DivideByZeroException>(() => ExifHelper.GetRational(property));
        }

        [Test]
        public void GetRationalWithIndexThrowsErrorOnZeroDenominator()
        {
            var value =
                ExifTypeHelper.CreateRational(1, 1).Concat(ExifTypeHelper.CreateRational(0, 0)).ToArray();
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = value};
            Assert.Throws<DivideByZeroException>(() => ExifHelper.GetRational(property, 1));
        }

        [Test]
        public void GetSignedRationalThrowsErrorOnZeroDenominator()
        {
            var value = ExifTypeHelper.CreateSignedRational(0, 0);
            var property = new ExifProperty {Id = 0, Length = 1, Type = 4, Value = value};
            Assert.Throws<DivideByZeroException>(() => ExifHelper.GetSignedRational(property));
        }

        [Test]
        public void GetStringRemovesTrailingNulls()
        {
            var value = Encoding.ASCII.GetBytes("Test\0");
            var property = new ExifProperty {Id = 0, Length = value.Length, Type = 2, Value = value};

            var text = ExifHelper.GetString(property);

            text.Should().NotEndWith("\0");
        }

        [Test]
        public void GetStringReturnsExpectedValue()
        {
            var value = Encoding.ASCII.GetBytes("Test\0");
            var property = new ExifProperty {Id = 0, Length = value.Length, Type = 2, Value = value};

            var text = ExifHelper.GetString(property);

            text.Should().Be("Test");
        }
    }
}