namespace MetadataExtractor.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ExtractorTests
    {
        [Test]
        public void HeightAndWidthProcessedWhenNoProcessorsPresent()
        {
            var extractor = new Extractor
            {
                Processors = new List<IMetaDataElementProcessor>()
            };

            var metadata = extractor.Extract(TestResources.TinyJpeg());

            metadata.Height.Should().Be(7);
            metadata.Width.Should().Be(10);
        }

        [Test]
        public void ProcessorCalledForPropertyIfPresent()
        {
            var processor = new TestProcessor();
            var extractor = new Extractor
            {
                Processors = new List<IMetaDataElementProcessor> {processor}
            };

            extractor.Extract(TestResources.TinyJpeg());
            processor.Called.Should().BeTrue();
        }

        [Test]
        public void ProcessorsPopulatedOnCreation()
        {
            var extractor = new Extractor();
            extractor.Processors.Should().NotBeEmpty();
        }
    }
}