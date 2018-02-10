namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Log;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ContrastProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ContrastProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0000, ContrastEnum.Normal)]
        [TestCase((ushort) 0x0001, ContrastEnum.Soft)]
        [TestCase((ushort) 0x0002, ContrastEnum.Hard)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ContrastEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};

            ((TestLog) ((ContrastProcessor) _processor).Log).Messages.Clear();
            _processor.Process(metadata, property);
            metadata.Contrast.Should().BeEquivalentTo(result);
            if (metadata.Contrast == null)
            {
                ((TestLog) ((ContrastProcessor) _processor).Log).Messages.Count.Should().Be(1);
            }
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA408);
        }
    }
}