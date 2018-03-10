namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureProgramProcessorTests:EnumTest<ExposureProgramProcessor, ExposureProgramEnum,ushort>
    {
        public ExposureProgramProcessorTests()
            :base(x=>x.ExposureProgram, "/app1/ifd/exif/{ushort=34850}")
        {
        }
    }
}
