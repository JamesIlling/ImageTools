namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CfaPatternProcessorTests : ProcessorTests<CfaPatternProcessor>
    {
        public CfaPatternProcessorTests()
            : base("/app1/ifd/exif/{ushort=41730}")
        {}

        [Test]
        public void NoValueStoredIfInvalidGridSize()
        {
            var data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((ushort) 2));
            data.AddRange(BitConverter.GetBytes((ushort) 2));

            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data.ToArray()));

            var result = metadata.ColourFilterArrayPattern;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNotBitmapMetadataBlob()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, "test");

            var result = metadata.ColourFilterArrayPattern;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, null);

            var result = metadata.ColourFilterArrayPattern;
            result.Should().BeNull();
        }

        [Test]
        public void ValueStoredIfBigEndianGridSize()
        {
            var data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((ushort) 2));
            data.AddRange(BitConverter.GetBytes((ushort) 2));
            data.Add(0x00);
            data.Add(0x01);
            data.Add(0x02);
            data.Add(0x03);

            var expected = new[,]
            {
                {ColourFilterArray.Red, ColourFilterArray.Green},
                {ColourFilterArray.Blue, ColourFilterArray.Cyan}
            };

            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data.ToArray()));

            var result = metadata.ColourFilterArrayPattern;

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ValueStoredIfLittleEndianGridSize()
        {
            var data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((ushort) 2).Reverse());
            data.AddRange(BitConverter.GetBytes((ushort) 2).Reverse());
            data.Add(0x04);
            data.Add(0x05);
            data.Add(0x06);
            data.Add(0x00);

            var expected = new[,]
            {
                {ColourFilterArray.Magenta, ColourFilterArray.Yellow},
                {ColourFilterArray.White, ColourFilterArray.Red}
            };

            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data.ToArray()));

            var result = metadata.ColourFilterArrayPattern;

            result.Should().BeEquivalentTo(expected);
        }
    }
}