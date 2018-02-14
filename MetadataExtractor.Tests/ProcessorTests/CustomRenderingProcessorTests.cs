namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CustomRenderingProcessorTests : EnumTests<CustomRenderingProcessor>
    {
        public CustomRenderingProcessorTests()
            : base(0xA401, "CustomRendering")
        {}


        [TestCase((ushort) 0x0000, CustomRenderingEnum.NormalProcess)]
        [TestCase((ushort) 0x0001, CustomRenderingEnum.CustomProcess)]
        [TestCase((ushort) 0x0003, CustomRenderingEnum.HDR)]
        [TestCase((ushort) 0x0006, CustomRenderingEnum.Panorama)]
        [TestCase((ushort) 0x0008, CustomRenderingEnum.Portrait)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, CustomRenderingEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(value)};
            Processor.Process(metadata, property);
            metadata.CustomRendering.Should().BeEquivalentTo(result);
        }
    }
}