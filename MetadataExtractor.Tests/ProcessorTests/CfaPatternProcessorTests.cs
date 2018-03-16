using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using FluentAssertions;
using MetadataExtractor.Enums;
using MetadataExtractor.Processors;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    [TestFixture]
    public class CfaPatternProcessorTests : ProcessorTests<CfaPatternProcessor>
    {
        public CfaPatternProcessorTests()
            :base("/app1/ifd/exif/{ushort=41730}")
        {   
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
        public void NoValueStoredIfPropertyIsNotBitmapMetadataBlob()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, "test");

            var result = metadata.ColourFilterArrayPattern;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfInvalidGridSize()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((ushort)2));
            data.AddRange(BitConverter.GetBytes((ushort)2));

            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data.ToArray()));

            var result = metadata.ColourFilterArrayPattern;
            result.Should().BeNull();
        }

        [Test]
        public void ValueStoredIfBigEndianGridSize()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((ushort)2));
            data.AddRange(BitConverter.GetBytes((ushort)2));
            data.Add(0x00);
            data.Add(0x01);
            data.Add(0x02);
            data.Add(0x03);

            var expected = new[,]
            {
                {ColourFilterArrayEnum.Red, ColourFilterArrayEnum.Green},
                {ColourFilterArrayEnum.Blue, ColourFilterArrayEnum.Cyan}
            };

            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data.ToArray()));

            var result = metadata.ColourFilterArrayPattern;
            
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ValueStoredIfLittleEndianGridSize()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((ushort)2).Reverse());
            data.AddRange(BitConverter.GetBytes((ushort)2).Reverse());
            data.Add(0x04);
            data.Add(0x05);
            data.Add(0x06);
            data.Add(0x00);

            var expected = new[,]
            {
                {ColourFilterArrayEnum.Magenta, ColourFilterArrayEnum.Yellow},
                {ColourFilterArrayEnum.White, ColourFilterArrayEnum.Red}
            };

            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data.ToArray()));

            var result = metadata.ColourFilterArrayPattern;

            result.Should().BeEquivalentTo(expected);
        }
    }
}
