namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ColourSpaceProcessorTests : EnumTest<ColourSpaceProcessor,ColourSpaceEnum,ushort>
    {
        public ColourSpaceProcessorTests()
            :base(x=>x.ColourSpace, "/app1/ifd/exif/{ushort=40961}")
        {
        }
    }
}
