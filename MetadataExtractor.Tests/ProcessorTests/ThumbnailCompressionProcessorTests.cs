namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailCompressionProcessorTests : EnumTests<ThumbnailCompressionProcessor, Compression>
    {
        public ThumbnailCompressionProcessorTests()
            : base(x => x.ThumbnailCompression, "/app1/thumb/{ushort=259}")
        { }
    }
}