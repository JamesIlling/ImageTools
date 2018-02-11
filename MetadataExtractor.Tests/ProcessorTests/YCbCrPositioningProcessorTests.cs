namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
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
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(value) };
            _processor.Process(metadata, property);
            metadata.YCbCrPositioning.Should().BeEquivalentTo(result);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x005) };
            var log = ((TestLog)((YCbCrPositioningProcessor)_processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(YCbCrPositioningProcessor.Error, 0x005));
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x213);
        }
    }
}