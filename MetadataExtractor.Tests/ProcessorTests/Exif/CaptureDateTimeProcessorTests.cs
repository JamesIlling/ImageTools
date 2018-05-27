namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class CaptureDateTimeProcessorTests : DateTimeTests<CaptureDateTimeProcessor>
    {
        public CaptureDateTimeProcessorTests()
            : base(x => x.CaptureTime, "/app1/ifd/exif/{ushort=36867}")
        { }
    }
}