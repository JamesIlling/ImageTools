namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureModeProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ExposureModeProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0000, ExposureModeEnum.Auto)]
        [TestCase((ushort) 0x0001, ExposureModeEnum.Manual)]
        [TestCase((ushort) 0x0002, ExposureModeEnum.AutoBracket)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ExposureModeEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};
            _processor.Process(metadata, property);
            metadata.ExposureMode.Should().BeEquivalentTo(result);
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA402);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x005)};
            var log = ((TestLog) ((ExposureModeProcessor) _processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(ExposureModeProcessor.Error, 0x005));
        }
    }
}