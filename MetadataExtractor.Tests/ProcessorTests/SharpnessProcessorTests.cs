namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class SharpnessProcessorTests : EnumTests<SharpnessProcessor, SharpnessEnum, ushort>
    {
        public SharpnessProcessorTests()
            : base(x => x.Sharpness, "/app1/ifd/exif/{ushort=41994}")
        {}
    }
}