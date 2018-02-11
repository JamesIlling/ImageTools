namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneYResolutionProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new FocalPlaneYResolutionProcessor();

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA20F);
        }

        [Test]
        public void MetadataFieldPopulated()
        {
            var value = ExifTypeHelper.CreateRational(1, 4);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = value };

            _processor.Process(metadata, property);

            metadata.FocalPlaneYResolution.Should().Be(0.25m);
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
