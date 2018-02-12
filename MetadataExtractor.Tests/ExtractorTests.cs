namespace MetadataExtractor.Tests
{
    using DependencyFactory;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;

    [TestFixture]
    public class ExtractorTests
    {
        [Test]
        public void HeightAndWidthProcessedWhenNoProcessorsPresent()
        {
            DependencyInjection.RegisterType<ILog, TestLog>();
            DependencyInjection.RegisterType<IGetProcessors, NoProcessors>();

            var extractor = DependencyInjection.Resolve<Extractor>();
            var metadata = extractor.Extract(TestResources.LightroomJpeg());

            metadata.Height.Should().Be(7);
            metadata.Width.Should().Be(10);
        }

        [Test]
        public void ProcessorCalledForPropertyIfPresent()
        {
            DependencyInjection.RegisterType<ILog, TestLog>();
            DependencyInjection.RegisterType<IGetProcessors, GetTestProcessor>();
            var extractor = DependencyInjection.Resolve<Extractor>();

            extractor.Extract(TestResources.LightroomJpeg());
            GetTestProcessor.Processor.Called.Should().BeTrue();
        }
    }
}