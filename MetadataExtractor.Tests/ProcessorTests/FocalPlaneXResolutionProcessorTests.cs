namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneXResolutionProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new FocalPlaneXResolutionProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA20E);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var value = ExifTypeHelper.CreateRational(1, 4);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            _processor.Process(metadata, property);

            metadata.FocalPlaneXResolution.Should().Be(0.25m);
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
