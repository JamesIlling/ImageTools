namespace MetadataExtractor.Tests
{
    using System.IO;
    using DependencyFactory;
    using Logging;
    using NUnit.Framework;

    [TestFixture]
    public class IntegrationTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DependencyInjection.RegisterType<ILog, TestLog>();
            DependencyInjection.RegisterType<IGetProcessors, ReflectionHelper>();
            DependencyInjection.RegisterType<IExploreMetadata, Explorer>();
            DependencyInjection.RegisterType<IExtractMetadata, Extractor>();
        }

        [Test]
        [Ignore("Breaks coverage")]
        public void CanProcessEos5DMkIv()
        {
            var processor = new StringDisplayer();
            var extractor = DependencyInjection.Resolve<IExtractMetadata>();
            var metadata = extractor.ExtractMetadata(TestResources.Eos5DMkIVJpeg());
            File.WriteAllText("e:\\Cannon4DMKIV.txt",processor.Read(metadata));
        }

        [Test]
        [Ignore("Breaks coverage")]
        public void CanProcessNikonD800()
        {
            var processor = new StringDisplayer();
            var extractor = DependencyInjection.Resolve<IExtractMetadata>();
            var metadata = extractor.ExtractMetadata(TestResources.D800EJpeg());
            File.WriteAllText("e:\\NikonD800E.txt", processor.Read(metadata));
        }

        [Test]
        [Ignore("Breaks coverage")]
        public void CanProcessLightroom()
        {
            var processor = new StringDisplayer();
            var extractor = DependencyInjection.Resolve<IExtractMetadata>();
            var metadata = extractor.ExtractMetadata(TestResources.LightroomJpeg());
            File.WriteAllText("e:\\Lightroom.txt", processor.Read(metadata));
        }

        [Test]
        [Ignore("Breaks coverage")]
        public void CanProcessAcdSee()
        {
            var processor = new StringDisplayer();
            var extractor = DependencyInjection.Resolve<IExtractMetadata>();
            var metadata = extractor.ExtractMetadata(TestResources.AcdSeeJpeg());
            File.WriteAllText("e:\\AcdSee.txt", processor.Read(metadata));
        }
    }
}