namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class FocalLength35MmEquivalentProcessorTests : ShortTests<FocalLength35MmEquivalentProcessor>
    {
        public FocalLength35MmEquivalentProcessorTests()
            : base(x => x.FocalLengthIn35MmFormat, "/app1/ifd/exif/{ushort=41989}")
        { }
    }
}