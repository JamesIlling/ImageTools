namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class YCbCrPositioningProcessorTests : EnumTests<YCbCrPositioningProcessor>
    {
        public YCbCrPositioningProcessorTests()
            : base(0x213, "YCbCrPositioning")
        {}

        private readonly IMetaDataElementProcessor _processor = new YCbCrPositioningProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0001, YCbCrPositioningEnum.Centered)]
        [TestCase((ushort) 0x0002, YCbCrPositioningEnum.CoSited)]
        [TestCase((ushort) 0x0009, null)]
        public void MetadataFieldPopulated(ushort value, YCbCrPositioningEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};
            _processor.Process(metadata, property);
            metadata.YCbCrPositioning.Should().BeEquivalentTo(result);
        }
    }
}