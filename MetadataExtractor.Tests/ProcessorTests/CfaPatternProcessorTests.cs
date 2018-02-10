namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CfaPatternProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new CfaPatternProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA302);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var value = new byte[] {0x01, 0x02, 0x03};
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = value};
            _processor.Process(metadata, property);
            metadata.CfaPattern.Should().BeEquivalentTo(value);
        }
    }
}