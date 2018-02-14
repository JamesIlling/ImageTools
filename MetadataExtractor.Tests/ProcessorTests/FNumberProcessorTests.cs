namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FNumberProcessorTests : RationalTests<FNumberProcessor>
    {
        public FNumberProcessorTests()
            : base(0x829D, "FNumber")
        {}
    }
}