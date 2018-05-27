namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class ContrastProcessorTests : EnumTests<ContrastProcessor, Contrast>
    {
        public ContrastProcessorTests()
            : base(x => x.Contrast, "/app1/ifd/exif/{ushort=41992}")
        { }
    }
}