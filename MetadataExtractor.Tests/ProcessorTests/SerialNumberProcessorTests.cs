namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class SerialNumberProcessorTests : StringTests<SerialNumberProcessor>
    {
        public SerialNumberProcessorTests()
            : base(0xA431, "CameraSerialNumber")
        {}
    }
}