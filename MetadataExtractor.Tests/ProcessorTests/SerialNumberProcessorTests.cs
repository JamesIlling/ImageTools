namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class SerialNumberProcessorTests : StringTests<SerialNumberProcessor>
    {
        public SerialNumberProcessorTests()
            : base(x => x.CameraSerialNumber, "/app1/ifd/exif/{ushort=42033}")
        {}
    }
}