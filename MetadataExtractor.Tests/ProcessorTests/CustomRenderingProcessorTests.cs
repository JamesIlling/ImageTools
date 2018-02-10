namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Log;
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
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};

            ((TestLog) ((CustomRenderingProcessor) _processor).Log).Messages.Clear();
            _processor.Process(metadata, property);
            metadata.CustomRendering.Should().BeEquivalentTo(result);
            if (metadata.CustomRendering == null)
            {
                ((TestLog) ((CustomRenderingProcessor) _processor).Log).Messages.Count.Should().Be(1);
            }
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xa401);
        }
    }
}