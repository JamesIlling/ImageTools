namespace MetadataExtractor.Tests
{
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;
    using TestClasses;

    [TestFixture]
    public class ExtractorTests
    {
        [Test]
        public void ExtractorUsesProcessorLocator()
        {
            var extractor = new Extractor {ProcessorLocator = new TestProcessorLocator()};
            var test = extractor.ProcessorLocator as TestProcessorLocator;

            extractor.ExtractMetadata(TestResources.LightroomJpeg());
            test.Should().NotBeNull();
            test.Called.Should().BeTrue();
        }

        [Test]
        public void ExtractorUsesProcessor()
        {
            var extractor = new Extractor { ProcessorLocator = new TestProcessorLocator(new TestProcessor()) };
            var test = extractor.ProcessorLocator as TestProcessorLocator;

            extractor.ExtractMetadata(TestResources.LightroomJpeg());
            var items = test.GetAll<ISupportQueries>();
            items.Count.Should().Be(1);
            items.Cast<TestProcessor>().First().Called.Should().BeTrue();


        }
    }
}
