namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ReferenceBlackWhiteProcessorTests : RationalTests<ReferenceBlackWhiteProcessor>
    {
        public ReferenceBlackWhiteProcessorTests()
            : base(0x0214, "ReferenceBlackWhite")
        {}
    }
}