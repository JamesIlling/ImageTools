namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailOffsetProcessorTests : LongTests<ThumbnailOffsetProcessor>
    {
        public ThumbnailOffsetProcessorTests()
            : base(x => x.ThumbnailOffset, "/app1/thumb/{ushort=513}")
        { }
    }
}