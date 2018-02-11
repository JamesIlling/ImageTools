
namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExifVersionProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ExifVersionProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x9000);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            const string text = "test";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            _processor.Process(metadata, property);

            metadata.ExifVersion.Should().Be(text);
        }
    }
}
