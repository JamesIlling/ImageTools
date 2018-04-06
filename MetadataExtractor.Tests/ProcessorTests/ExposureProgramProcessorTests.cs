namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ExposureProgramProcessorTests : EnumTests<ExposureProgramProcessor, ExposureProgram>
    {
        public ExposureProgramProcessorTests()
            : base(x => x.ExposureProgram, "/app1/ifd/exif/{ushort=34850}")
        { }
    }
}