namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Log;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class OrientationProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new OrientationProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0001, OrientationEnum.Horizontal)]
        [TestCase((ushort) 0x0002, OrientationEnum.MirrorHorizontal)]
        [TestCase((ushort) 0x0003, OrientationEnum.Rotate180)]
        [TestCase((ushort) 0x0004, OrientationEnum.MirrorVertical)]
        [TestCase((ushort) 0x0005, OrientationEnum.MirrorHorizontalAndRotate270)]
        [TestCase((ushort) 0x0006, OrientationEnum.Rotate90)]
        [TestCase((ushort) 0x0007, OrientationEnum.MirrorHorizontalAndRotate90)]
        [TestCase((ushort) 0x0008, OrientationEnum.Rotate270)]
        [TestCase((ushort) 0x0009, null)]
        public void MetadataFieldPopulated(ushort value, OrientationEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};

            ((TestLog) ((OrientationProcessor) _processor).Log).Messages.Clear();
            _processor.Process(metadata, property);
            metadata.Orientation.Should().BeEquivalentTo(result);
            if (metadata.Orientation == null)
            {
                ((TestLog) ((OrientationProcessor) _processor).Log).Messages.Count.Should().Be(1);
            }
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x0112);
        }
    }
}