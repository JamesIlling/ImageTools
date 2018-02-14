namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureModeProcessorTests : EnumTests<ExposureModeProcessor>
    {
        public ExposureModeProcessorTests()
            : base(0xA402, "ExposureMode")
        {}

        [TestCase((ushort) 0x0000, ExposureModeEnum.Auto)]
        [TestCase((ushort) 0x0001, ExposureModeEnum.Manual)]
        [TestCase((ushort) 0x0002, ExposureModeEnum.AutoBracket)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ExposureModeEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(value)};
            Processor.Process(metadata, property);
            metadata.ExposureMode.Should().BeEquivalentTo(result);
        }
    }
}