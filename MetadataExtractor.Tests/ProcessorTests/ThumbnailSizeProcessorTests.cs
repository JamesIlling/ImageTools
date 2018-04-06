namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailSizeProcessorTests : LongTests<ThumbnailSizeProcessor>
    {
        public ThumbnailSizeProcessorTests()
            : base(x => x.ThumbnailSize, "/app1/thumb/{ushort=514}")
        { }
    }
}