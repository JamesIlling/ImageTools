namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    public class CameraSerialProcessorTest
    {
        private readonly IMetaDataElementProcessor _processor = new CameraSerialProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xC62F);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            const string text = "test";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = value};
            _processor.Process(metadata, property);
            metadata.CameraSerialNumber.Should().Be(text);
        }

        [Test]
        public void MetadataFieldNotPopulatedIfValueExists()
        {
            const string text = "test";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata {CameraSerialNumber = "1"};
            var property = new ExifProperty {Id = _processor.Id, Value = value};
            _processor.Process(metadata, property);
            metadata.CameraSerialNumber.Should().Be("1");
        }
    }
}