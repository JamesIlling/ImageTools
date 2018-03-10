
namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ThumbnailCompressionProcessorTests : EnumTest<ThumbnailCompressionProcessor,CompressionEnum,ushort>
    {
        public ThumbnailCompressionProcessorTests()
            :base(x=>x.ThumbnailCompression, "/app1/thumb/{ushort=259}")
        {
        }
    }
}
