namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class PixelYDimensionProcessorTests : ShortTests<PixelYDimensionProcessor>
    {
        public PixelYDimensionProcessorTests()
            : base(x => x.Height, "/app1/ifd/exif/{ushort=40963}")
        { }
    }
}