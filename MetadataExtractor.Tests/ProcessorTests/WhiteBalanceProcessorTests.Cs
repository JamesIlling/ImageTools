namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class WhiteBalanceProcessorTests : EnumTests<WhiteBalanceProcessor, WhiteBalanceEnum, ushort>
    {
        public WhiteBalanceProcessorTests()
            : base(x => x.WhiteBalance, "/app1/ifd/exif/{ushort=41987}")
        {}
    }
}