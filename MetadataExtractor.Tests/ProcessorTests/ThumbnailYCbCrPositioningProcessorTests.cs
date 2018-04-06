namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using Processors;
    using TestBaseClasses;

    public class ThumbnailYCbCrPositioningProcessorTests
        : EnumTests<ThumbnailYCbCrPositioningProcessor, YCbCrPositioning>
    {
        public ThumbnailYCbCrPositioningProcessorTests()
            : base(x => x.ThumbnailYCbCrPositioning, "/app1/thumb/{ushort=531}")
        {}
    }
}