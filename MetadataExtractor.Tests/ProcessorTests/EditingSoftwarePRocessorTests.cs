
namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class EditingSoftwareProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new EditingSoftwareProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x0131);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            const string text = "test";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            _processor.Process(metadata, property);

            metadata.EditingSoftware.Should().Be(text);
        }
    }
}
