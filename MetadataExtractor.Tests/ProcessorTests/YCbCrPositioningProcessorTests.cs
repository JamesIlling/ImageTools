namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class YCbCrPositioningProcessorTests : EnumTests<YCbCrPositioningProcessor, YCbCrPositioningEnum, ushort>
    {
        public YCbCrPositioningProcessorTests()
            : base(x => x.YCbCrPositioning, "/app1/ifd/{ushort=531}")
        {}
    }
}