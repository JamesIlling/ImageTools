namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalLengthProcessorTests : RationalTests<FocalLengthProcessor>
    {
        public FocalLengthProcessorTests()
            : base(0x920A, "FocalLength")
        {}
    }
}