namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureProgramProcessorTests : EnumTests<ExposureProgramProcessor>
    {
        public ExposureProgramProcessorTests()
            : base(0x8822, "ExposureProgram")
        {}

        [TestCase((ushort) 0x0000, ExposureProgramEnum.NotDefined)]
        [TestCase((ushort) 0x0001, ExposureProgramEnum.Manual)]
        [TestCase((ushort) 0x0002, ExposureProgramEnum.Program)]
        [TestCase((ushort) 0x0003, ExposureProgramEnum.AperturePriority)]
        [TestCase((ushort) 0x0004, ExposureProgramEnum.ShutterPriority)]
        [TestCase((ushort) 0x0005, ExposureProgramEnum.Creative)]
        [TestCase((ushort) 0x0006, ExposureProgramEnum.Action)]
        [TestCase((ushort) 0x0007, ExposureProgramEnum.Portrait)]
        [TestCase((ushort) 0x0008, ExposureProgramEnum.Landscape)]
        [TestCase((ushort) 0x0009, ExposureProgramEnum.Bulb)]
        [TestCase((ushort) 0x000A, null)]
        public void MetadataFieldPopulated(ushort value, ExposureProgramEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(value)};
            Processor.Process(metadata, property);
            metadata.ExposureProgram.Should().BeEquivalentTo(result);
        }
    }
}