namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class SharpnessProcessorTests : EnumTests<SharpnessProcessor, Sharpness>
    {
        public SharpnessProcessorTests()
            : base(x => x.Sharpness, "/app1/ifd/exif/{ushort=41994}")
        { }
    }
}