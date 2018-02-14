namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class OrientationProcessorTests : EnumTests<OrientationProcessor>
    {
        public OrientationProcessorTests()
            : base(0x0112, "Orientation")
        {}

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
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(value)};
            Processor.Process(metadata, property);
            metadata.Orientation.Should().BeEquivalentTo(result);
        }
    }
}