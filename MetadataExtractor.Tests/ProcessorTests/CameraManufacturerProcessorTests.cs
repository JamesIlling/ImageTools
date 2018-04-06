namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CameraManufacturerProcessorTests : StringTests<CameraManufacturerProcessor>
    {
        public CameraManufacturerProcessorTests()
            : base(x => x.CameraManufacturer, "/app1/ifd/{ushort=271}")
        { }
    }
}