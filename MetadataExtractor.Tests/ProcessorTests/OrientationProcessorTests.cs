namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
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
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(value) };
            _processor.Process(metadata, property);
            metadata.Orientation.Should().BeEquivalentTo(result);
        }


        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x009) };
            var log = ((TestLog)((OrientationProcessor)_processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(OrientationProcessor.Error, 0x009));
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x0112);
        }
    }
}