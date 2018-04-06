namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailYCbCrPositioningProcessorTests
        : EnumTests<ThumbnailYCbCrPositioningProcessor, YCbCrPositioning>
    {
        public ThumbnailYCbCrPositioningProcessorTests()
            : base(x => x.ThumbnailYCbCrPositioning, "/app1/thumb/{ushort=531}")
        { }
    }
}