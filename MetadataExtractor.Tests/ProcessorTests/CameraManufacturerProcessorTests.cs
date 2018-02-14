namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CameraManufacturerProcessorTests : StringTests<CameraManufacturerProcessor>
    {
        public CameraManufacturerProcessorTests()
            : base(0x010F, "CameraManufacturer")
        {}
    }
}