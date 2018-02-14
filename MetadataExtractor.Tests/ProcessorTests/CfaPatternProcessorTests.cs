namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CfaPatternProcessorTests : ByteArrayTests<CfaPatternProcessor>
    {
        public CfaPatternProcessorTests()
            : base(0xA302, "CfaPattern")
        {}
    }
}