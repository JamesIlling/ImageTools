namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ContrastProcessorTests : EnumTests<ContrastProcessor>
    {
        public ContrastProcessorTests()
            : base(0xa408, "Contrast")
        {}

        private readonly IMetaDataElementProcessor _processor = new ContrastProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0000, ContrastEnum.Normal)]
        [TestCase((ushort) 0x0001, ContrastEnum.Soft)]
        [TestCase((ushort) 0x0002, ContrastEnum.Hard)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ContrastEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};
            _processor.Process(metadata, property);
            metadata.Contrast.Should().BeEquivalentTo(result);
        }
    }
}