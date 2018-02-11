namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CustomRenderingProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new CustomRenderingProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0000, CustomRenderingEnum.NormalProcess)]
        [TestCase((ushort) 0x0001, CustomRenderingEnum.CustomProcess)]
        [TestCase((ushort) 0x0003, CustomRenderingEnum.HDR)]
        [TestCase((ushort) 0x0006, CustomRenderingEnum.Panorama)]
        [TestCase((ushort) 0x0008, CustomRenderingEnum.Portrait)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, CustomRenderingEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(value) };
            _processor.Process(metadata, property);
            metadata.CustomRendering.Should().BeEquivalentTo(result);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x005) };
            var log = ((TestLog) ((CustomRenderingProcessor) _processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message =log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(CustomRenderingProcessor.Error, 0x005));
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xa401);
        }
    }
}