namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CaptureDateTimeSubsecondProcessorTests : DateTimeSubSecondsTests<CaptureDateTimeSubsecondProcessor>
    {
        public CaptureDateTimeSubsecondProcessorTests()
            : base(
                x => x.CaptureTime, (metadata, datetime) => metadata.CaptureTime = datetime,
                "/app1/ifd/exif/{ushort=37521}")
        { }
    }
}