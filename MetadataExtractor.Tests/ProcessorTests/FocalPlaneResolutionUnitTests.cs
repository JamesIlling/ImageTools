namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneResolutionUnitTests
    {
        private readonly IMetaDataElementProcessor _processor = new FocalPlaneResolutionUnitProcessor
        {
            Log = new TestLog()
        };

        [TestCase((ushort) 0x0000, ResolutionUnitEnum.Unknown)]
        [TestCase((ushort) 0x0001, ResolutionUnitEnum.NoUnitsOfMeasure)]
        [TestCase((ushort) 0x0002, ResolutionUnitEnum.Inches)]
        [TestCase((ushort) 0x0003, ResolutionUnitEnum.Centimeters)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ResolutionUnitEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};
            _processor.Process(metadata, property);
            metadata.FocalPlaneResolutionUnit.Should().BeEquivalentTo(result);
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA210);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x005)};
            var log = ((TestLog) ((FocalPlaneResolutionUnitProcessor) _processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(FocalPlaneResolutionUnitProcessor.Error, 0x005));
        }
    }
}