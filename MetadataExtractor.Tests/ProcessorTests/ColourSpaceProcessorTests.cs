namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ColourSpaceProcessorTests : EnumTests<ColourSpaceProcessor, ColourSpace>
    {
        public ColourSpaceProcessorTests()
            : base(x => x.ColourSpace, "/app1/ifd/exif/{ushort=40961}")
        {}
    }
}