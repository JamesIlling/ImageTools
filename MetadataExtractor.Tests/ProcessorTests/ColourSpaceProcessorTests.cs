namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ColourSpaceProcessorTests : EnumTests<ColourSpaceProcessor>
    {
        public ColourSpaceProcessorTests()
            : base(0xA001, "ColourSpace")
        {}

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
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(value)};
            Processor.Process(metadata, property);
            metadata.ColourSpace.Should().BeEquivalentTo(result);
        }
    }
}