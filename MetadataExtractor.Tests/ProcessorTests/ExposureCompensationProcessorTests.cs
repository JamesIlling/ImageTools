namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureCompensationProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ExposureCompensationProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x9204);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var rational = ExifTypeHelper.CreateSignedRational(4, -8);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = rational };

            _processor.Process(metadata, property);

            metadata.ExposureCompensation.Should().Be(-0.5m);
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
