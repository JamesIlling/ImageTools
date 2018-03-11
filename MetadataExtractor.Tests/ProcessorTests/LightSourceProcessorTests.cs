namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class LightSourceProcessorTests : EnumTests<LightSourceProcessor, LightSourceEnum, ushort>
    {
        public LightSourceProcessorTests()
            : base(x => x.Lightsource, "/app1/ifd/exif/{ushort=37384}")
        {}
    }
}