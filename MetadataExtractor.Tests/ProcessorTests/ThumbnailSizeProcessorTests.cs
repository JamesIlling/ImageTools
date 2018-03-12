using MetadataExtractor.Processors;
using MetadataExtractor.Tests.TestBaseClasses;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    [TestFixture]
    public class ThumbnailSizeProcessorTests : LongTests<ThumbnailSizeProcessor>
    {
        public ThumbnailSizeProcessorTests()
            : base(x => x.ThumbnailSize, "/app1/thumb/{ushort=514}")
        {
        }
    }
}