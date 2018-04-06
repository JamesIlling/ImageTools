namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class PixelXDimensionProcessorTests : ShortTests<PixelXDimensionProcessor>
    {
        public PixelXDimensionProcessorTests()
            : base(x => x.Width, "/app1/ifd/exif/{ushort=40962}")
        {}
    }
}