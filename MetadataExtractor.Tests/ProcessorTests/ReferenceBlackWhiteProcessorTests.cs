namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ReferenceBlackWhiteProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ReferenceBlackWhiteProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x0214);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var value = ExifTypeHelper.CreateRational(1, 4);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = value};

            _processor.Process(metadata, property);

            metadata.ReferenceBlackWhite.Should().Be(0.25m);
        }
    }
}