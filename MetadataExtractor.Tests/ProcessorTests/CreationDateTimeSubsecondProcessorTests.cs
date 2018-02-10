namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CreationDateTimeSubsecondProcessorTests
    {
        // This is also known as DateTimeOriginal Subscecond, this is only populated if there is already a datetime
        private readonly IMetaDataElementProcessor _processor = new CreationDateTimeSubsecondProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x9292);
        }

        [Test]
        public void MetadataFieldNotPopulatedIfCaptureDateNotSet()
        {
            const string text = "100";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = value};

            _processor.Process(metadata, property);
            metadata.CreationTime.Should().BeNull();
        }

        [Test]
        public void MetadataFieldPopulatedIfCaptureDateAlreadySet()
        {
            const string text = "100";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata {CreationTime = new DateTime(2000, 01, 01, 00, 00, 00)};
            var property = new ExifProperty {Id = _processor.Id, Value = value};

            _processor.Process(metadata, property);
            metadata.CreationTime.Should().NotBeNull();
            if (metadata.CreationTime != null)
            {
                metadata.CreationTime.Value.Millisecond.Should().Be(100);
            }
        }
    }
}