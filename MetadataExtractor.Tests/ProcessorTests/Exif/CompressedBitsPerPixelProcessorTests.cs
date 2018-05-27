namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class CompressedBitsPerPixelProcessorTests : RationalTests<CompressedBitsPerPixelProcessor>
    {
        public CompressedBitsPerPixelProcessorTests()
            : base(x => x.CompressedBitsPerPixel, "/app1/ifd/exif/{ushort=37122}")
        { }
    }
}