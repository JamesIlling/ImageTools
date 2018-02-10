namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Log;
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
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};

            ((TestLog) ((ColourSpaceProcessor) _processor).Log).Messages.Clear();
            _processor.Process(metadata, property);
            metadata.ColourSpace.Should().BeEquivalentTo(result);
            if (metadata.ColourSpace == null)
            {
                ((TestLog) ((ColourSpaceProcessor) _processor).Log).Messages.Count.Should().Be(1);
            }
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA001);
        }
    }
}