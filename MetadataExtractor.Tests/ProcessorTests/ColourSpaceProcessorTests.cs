namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ColourSpaceProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ColourSpaceProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0000, ColourSpaceEnum.Unknown)]
        [TestCase((ushort) 0x0001, ColourSpaceEnum.sRGB)]
        [TestCase((ushort) 0x0002, ColourSpaceEnum.AdobeRGB)]
        [TestCase((ushort) 0x0005, null)]
        [TestCase((ushort) 0xFFFD, ColourSpaceEnum.WideGamutRGB)]
        [TestCase((ushort) 0xFFFE, ColourSpaceEnum.ICCProfile)]
        [TestCase((ushort) 0xFFFF, ColourSpaceEnum.Uncalibrated)]
        public void MetadataFieldPopulated(ushort value, ColourSpaceEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(value) };
            _processor.Process(metadata, property);
            metadata.ColourSpace.Should().BeEquivalentTo(result);
        }


        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x005) };
            var log = ((TestLog)((ColourSpaceProcessor)_processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(ColourSpaceProcessor.Error, 0x005));
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA001);
        }
    }
}