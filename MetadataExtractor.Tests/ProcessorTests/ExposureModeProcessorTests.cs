namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureModeProcessorTests : EnumTest<ExposureModeProcessor, ExposureModeEnum,ushort>
    {
        public ExposureModeProcessorTests()
            :base(x=>x.ExposureMode, "/app1/ifd/exif/{ushort=41986}")
        {
        }
    }
}
