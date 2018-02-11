namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class RecommendedExposureIndexProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new RecommendedExposureIndexProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x8832);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            const uint val = 32;
            var value = ExifTypeHelper.CreateLong(val);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            _processor.Process(metadata, property);

            metadata.RecommendedExposureIndex.Should().Be(val);
        }
    }
}
