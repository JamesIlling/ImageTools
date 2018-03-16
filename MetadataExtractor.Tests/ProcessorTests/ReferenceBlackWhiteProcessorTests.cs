using System;
using System.Linq;
using FluentAssertions;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ReferenceBlackWhiteProcessorTests : ProcessorTests<ReferenceBlackWhiteProcessor>
    {
        public ReferenceBlackWhiteProcessorTests()
            : base("/app1/ifd/{ushort=532}")
        {
        }

        [Test]
        public void ExceptionThrownIfDenominatorIsZero()
        {
            const ulong input = 0ul;
            var metadata = new Metadata();
            Assert.Throws(typeof(DivideByZeroException), () => Processor.Process(metadata, new[] {input}));
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
         
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = metadata.ReferenceBlackWhite;
            result.Should().BeNull();
        }

        [TestCase(1u, 1u, 1)]
        [TestCase(1u, 2u, 0.5)]
        [TestCase(2u, 1u, 2)]
        [TestCase(uint.MaxValue, uint.MaxValue, 1)]
        [TestCase(uint.MaxValue, 1u, 4294967295d)]
        [TestCase(uint.MinValue, uint.MaxValue, 0)]
        public void ValidValueWrittenToMetadata(uint numerator, uint denominator, decimal? expected)
        {
            var component = BitConverter.GetBytes(numerator).ToList();
            component.AddRange(BitConverter.GetBytes(denominator));
            var input = new[] {BitConverter.ToUInt64(component.ToArray(), 0)};

            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = metadata.ReferenceBlackWhite.First();
            result.Should().Be(expected);
        }
    }
}
