namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Text;
    using System.Windows.Media.Imaging;
    using DependencyFactory;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExifVersionProcessorTests : ProcessorTests<ExifVersionProcessor>
    {
        public ExifVersionProcessorTests()
            : base("/app1/ifd/exif/{ushort=36864}")
        {}

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var processor = DependencyInjection.Resolve<ExifVersionProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, null);

            var result = metadata.ExifVersion;
            result.Should().BeNull();
        }

        [Test]
        public void ValueStoredIfPropertyIsNotNull()
        {
            var processor = DependencyInjection.Resolve<ExifVersionProcessor>();
            var metadata = new Metadata();
            const string value = "2.1.3";
            var data = new BitmapMetadataBlob(Encoding.ASCII.GetBytes(value));
            processor.Process(metadata, data);

            var result = metadata.ExifVersion;
            result.Should().Be(value);
        }
    }
}