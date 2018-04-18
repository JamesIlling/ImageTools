namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifThumbnailXProcessorTests : DecimalsFromBytesTests<JfifThumbnailXProcessor>
    {
        public JfifThumbnailXProcessorTests()
            : base(x => x.ThumbnailXResolution, "/app0/{ushort=4}")
        { }
    }
}