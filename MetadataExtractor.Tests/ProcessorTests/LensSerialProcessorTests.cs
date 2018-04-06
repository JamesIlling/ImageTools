namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class LensSerialProcessorTests : StringTests<LensSerialProcessor>
    {
        public LensSerialProcessorTests()
            : base(x => x.LensSerialNumber, "/app1/ifd/exif/{ushort=42037}")
        { }
    }
}