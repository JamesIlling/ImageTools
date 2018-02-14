namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneResolutionUnitTests : EnumTests<FocalPlaneResolutionUnitProcessor>
    {
        public FocalPlaneResolutionUnitTests()
            : base(0xA210, "FocalPlaneResolutionUnit")
        {}

        private readonly IMetaDataElementProcessor _processor = new FocalPlaneResolutionUnitProcessor
        {
            Log = new TestLog()
        };

        [TestCase((ushort) 0x0000, ResolutionUnitEnum.Unknown)]
        [TestCase((ushort) 0x0001, ResolutionUnitEnum.NoUnitsOfMeasure)]
        [TestCase((ushort) 0x0002, ResolutionUnitEnum.Inches)]
        [TestCase((ushort) 0x0003, ResolutionUnitEnum.Centimeters)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ResolutionUnitEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};
            _processor.Process(metadata, property);
            metadata.FocalPlaneResolutionUnit.Should().BeEquivalentTo(result);
        }
    }
}