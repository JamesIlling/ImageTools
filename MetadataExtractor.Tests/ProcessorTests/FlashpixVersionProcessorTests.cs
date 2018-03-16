namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Text;
    using System.Windows.Media.Imaging;
    using DependencyFactory;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;
    class FlashpixVersionProcessorTests : ProcessorTests<FlashPixVersionProcessor>
    {
        public FlashpixVersionProcessorTests()
            :base("/app1/ifd/exif/{ushort=40960}")
        {
        }


        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var processor = DependencyInjection.Resolve<FlashPixVersionProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, null);

            var result = metadata.FlashpixVersion;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNotBitmapMetadataBlob()
        {
            var processor = DependencyInjection.Resolve<FlashPixVersionProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, "");

            var result = metadata.FlashpixVersion;
            result.Should().BeNull();
        }

        public void ValidValueWrittenToMetadata()
        {
            var processor = DependencyInjection.Resolve<FlashPixVersionProcessor>();
            var metadata = new Metadata();
            var input = new BitmapMetadataBlob(Encoding.ASCII.GetBytes("test"));

            processor.Process(metadata, input);

            var result = metadata.FlashpixVersion;
            result.Should().Be("test");
        }
    }
}
