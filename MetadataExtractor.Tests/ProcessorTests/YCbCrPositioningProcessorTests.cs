namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Log;
    using NUnit.Framework;
    using Processors;

    public class YCbCrPositioningProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new YCbCrPositioningProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0001, YCbCrPositioningEnum.Centered)]
        [TestCase((ushort) 0x0002, YCbCrPositioningEnum.CoSited)]
        [TestCase((ushort) 0x0009, null)]
        public void MetadataFieldPopulated(ushort value, YCbCrPositioningEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};

            ((TestLog) ((YCbCrPositioningProcessor) _processor).Log).Messages.Clear();
            _processor.Process(metadata, property);
            metadata.YCbCrPositioning.Should().BeEquivalentTo(result);
            if (metadata.YCbCrPositioning == null)
            {
                ((TestLog) ((YCbCrPositioningProcessor) _processor).Log).Messages.Count.Should().Be(1);
            }
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x213);
        }
    }
}