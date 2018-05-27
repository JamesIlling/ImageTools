namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class FlashpixVersionProcessorTests : SeparatedStringProcessorTests<FlashPixVersionProcessor>
    {
        public FlashpixVersionProcessorTests()
            : base(x => x.FlashpixVersion, "/app1/ifd/exif/{ushort=40960}")
        { }
    }
}