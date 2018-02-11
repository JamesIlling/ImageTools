namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureTimeProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ExposureTimeProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x829A);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var rational = ExifTypeHelper.CreateSignedRational(4, -8);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = rational };

            _processor.Process(metadata, property);

            metadata.ExposureTime.Should().Be(-0.5m);
        }

        [Test]
        public void ProcessorThrowExecptionwhenDemoninatorIsZero()
        {
            var value = ExifTypeHelper.CreateSignedRational(1, 0);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            Assert.Throws<DivideByZeroException>(() => _processor.Process(metadata, property));
        }
    }
}
