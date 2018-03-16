namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ContrastProcessorTests : EnumTests<ContrastProcessor, ContrastEnum, ushort>
    {
        public ContrastProcessorTests()
            : base(x => x.Contrast, "/app1/ifd/exif/{ushort=41992}")
        {}
    }
}