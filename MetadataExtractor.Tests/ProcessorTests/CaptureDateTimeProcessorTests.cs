namespace MetadataExtractor.Tests.ProcessorTests
{
    using Processors;
    using TestBaseClasses;

    public class CaptureDateTimeProcessorTests : DateTimeTests<CaptureDateTimeProcessor>
    {
        public CaptureDateTimeProcessorTests()
            : base(x => x.CaptureTime, "/app1/ifd/exif/{ushort=36867}")
        {}
    }
}