namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class LightSourceProcessorTests : EnumTests<LightSourceProcessor, LightSource>
    {
        public LightSourceProcessorTests()
            : base(x => x.Lightsource, "/app1/ifd/exif/{ushort=37384}")
        { }
    }
}