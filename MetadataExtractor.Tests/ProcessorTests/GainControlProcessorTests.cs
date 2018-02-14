namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class GainControlProcessorTests : EnumTests<GainControlProcessor>
    {
        public GainControlProcessorTests()
            : base(0xa407, "ColourSpace")
        {}

        [TestCase((ushort) 0x0000, GainControlEnum.None)]
        [TestCase((ushort) 0x0001, GainControlEnum.LowGainUp)]
        [TestCase((ushort) 0x0002, GainControlEnum.HighGainUp)]
        [TestCase((ushort) 0x0003, GainControlEnum.LowGainDown)]
        [TestCase((ushort) 0x0004, GainControlEnum.HighGainDown)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, GainControlEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(value)};
            Processor.Process(metadata, property);
            metadata.GainControl.Should().BeEquivalentTo(result);
        }
    }
}