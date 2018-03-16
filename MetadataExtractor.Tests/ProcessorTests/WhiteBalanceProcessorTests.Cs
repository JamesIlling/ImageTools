namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class WhiteBalanceProcessorTests : EnumTests<WhiteBalanceProcessor, WhiteBalance>
    {
        public WhiteBalanceProcessorTests()
            : base(x => x.WhiteBalance, "/app1/ifd/exif/{ushort=41987}")
        {}
    }
}