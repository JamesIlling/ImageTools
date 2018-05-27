namespace MetadataExtractor.Tests.ProcessorTests.Jfif
{
    using NUnit.Framework;
    using Processors.Jfif;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailXProcessorTests : DecimalsFromBytesTests<ThumbnailXProcessor>
    {
        public ThumbnailXProcessorTests()
            : base(x => x.ThumbnailXResolution, "/app0/{ushort=4}")
        { }
    }
}