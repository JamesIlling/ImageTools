namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CaptureDateTimeProcessorTests
    {
        // This is also known as DateTimeOriginal
        private readonly IMetaDataElementProcessor _processor = new CaptureDateTimeProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x9003);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            const string text = "2001:02:01 19:00:01";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = value};
            _processor.Process(metadata, property);
            metadata.CaptureTime.Should().Be(new DateTime(2001, 02, 01, 19, 00, 01));
        }
    }
}