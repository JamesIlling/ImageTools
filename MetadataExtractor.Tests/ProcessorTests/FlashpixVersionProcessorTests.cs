namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Text;
    using System.Windows.Media.Imaging;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FlashpixVersionProcessorTests : ProcessorTests<FlashPixVersionProcessor>
    {
        public FlashpixVersionProcessorTests()
            : base("/app1/ifd/exif/{ushort=40960}")
        {}

        [Test]
        public void NoValueStoredIfPropertyIsNotBitmapMetadataBlob()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, "");

            var result = metadata.FlashpixVersion;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = metadata.FlashpixVersion;
            result.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var metadata = new Metadata();
            var input = new BitmapMetadataBlob(Encoding.ASCII.GetBytes("test"));

            Processor.Process(metadata, input);

            var result = metadata.FlashpixVersion;
            result.Should().Be("test");
        }
    }
}