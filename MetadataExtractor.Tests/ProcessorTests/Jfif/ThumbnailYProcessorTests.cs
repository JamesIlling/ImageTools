namespace MetadataExtractor.Tests.ProcessorTests.Jfif
{
    using NUnit.Framework;
    using Processors.Jfif;
    using TestBaseClasses;

    [TestFixture]
    public class JfifThumbnailYProcessorTests : DecimalsFromBytesTests<ThumbnailYProcessor>
    {
        public JfifThumbnailYProcessorTests()
            : base(x => x.ThumbnailYResolution, "/app0/{ushort=5}")
        { }
    }
}