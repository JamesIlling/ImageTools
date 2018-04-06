namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class IsoProcessorTests : ShortTests<IsoProcessor>
    {
        public IsoProcessorTests()
            : base(x => x.Iso, "/app1/ifd/exif/{ushort=34855}")
        {}
    }
}