namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifThumbnailYProcessorTests : DecimalsFromBytesTests<JfifThumbnailYProcessor>
    {
        public JfifThumbnailYProcessorTests()
            : base(x => x.ThumbnailYResolution, "/app0/{ushort=5}")
        { }
    }
}