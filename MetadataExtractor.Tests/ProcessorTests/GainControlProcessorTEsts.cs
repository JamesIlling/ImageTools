namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class GainControlProcessorTests : EnumTests<GainControlProcessor, GainControlEnum, ushort>
    {
        public GainControlProcessorTests()
            : base(x => x.GainControl, "/app1/ifd/exif/{ushort=41991}")
        {}
    }
}