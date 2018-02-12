namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    public class FocalLength35MmEquivalentProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new FocalLength35MmEquivalentProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xa405);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var shortValue = ExifTypeHelper.GetShort(0x0001);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = shortValue };

            _processor.Process(metadata, property);

            metadata.FocalLengthIn35MmFormat.Should().Be(1);
        }
    }
}
