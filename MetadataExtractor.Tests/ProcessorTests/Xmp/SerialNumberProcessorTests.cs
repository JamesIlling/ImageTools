namespace MetadataExtractor.Tests.ProcessorTests.Xmp
{
    using Processors.Xmp;
    using TestBaseClasses;

    public class SerialNumberProcessorTests : StringTests<SerialNumberProcessor>
    {
        public SerialNumberProcessorTests()
            : base(x => x.CameraSerialNumber, "/xmp/aux:SerialNumber")
        { }
    }
}