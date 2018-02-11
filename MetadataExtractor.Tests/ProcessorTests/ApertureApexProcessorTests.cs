namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ApertureApexProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ApertureApexProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x9202);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var rational = ExifTypeHelper.CreateRational(4, 8);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = rational};

            _processor.Process(metadata, property);

            metadata.ApertureApexValue.Should().Be(0.5m);
        }

        [Test]
        public void ProcessorThrowExecptionwhenDemoninatorIsZero()
        {
            var value = ExifTypeHelper.CreateRational(1, 0);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            Assert.Throws<DivideByZeroException>(() => _processor.Process(metadata, property));
        }
    }
}