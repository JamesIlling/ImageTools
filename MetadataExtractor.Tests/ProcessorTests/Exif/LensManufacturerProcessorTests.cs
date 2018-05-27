namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class LensManufacturerProcessorTests : StringTests<LensManufacturerProcessor>
    {
        public LensManufacturerProcessorTests()
            : base(x => x.LensManufacturer, "/app1/ifd/exif/{ushort=42035}")
        { }
    }
}