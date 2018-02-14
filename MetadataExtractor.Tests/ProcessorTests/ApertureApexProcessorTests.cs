namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ApertureApexProcessorTests : RationalTests<ApertureApexProcessor>
    {
        public ApertureApexProcessorTests()
            : base(0x9202, "ApertureApexValue")
        {}
    }
}