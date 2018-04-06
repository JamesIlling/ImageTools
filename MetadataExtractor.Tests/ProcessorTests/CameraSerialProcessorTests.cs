namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CameraSerialProcessorTests : StringTests<CameraSerialProcessor>
    {
        public CameraSerialProcessorTests()
            : base(x => x.CameraSerialNumber, "/app1/ifd/{ushort=50735}")
        {}
    }
}