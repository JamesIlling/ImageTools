using MetadataExtractor.Processors;
using MetadataExtractor.Tests.TestBaseClasses;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    [TestFixture]
    public class ThumbnailOffsetProcessorTests : LongTests<ThumbnailOffsetProcessor>
    {
        public ThumbnailOffsetProcessorTests()
            : base(x => x.ThumbnailOffset, "/app1/thumb/{ushort=513}")
        {
        }
    }
}