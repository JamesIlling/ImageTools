namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class GainControlProcessorTests : EnumTests<GainControlProcessor, GainControl>
    {
        public GainControlProcessorTests()
            : base(x => x.GainControl, "/app1/ifd/exif/{ushort=41991}")
        {}
    }
}