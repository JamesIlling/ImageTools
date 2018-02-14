namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class RecommendedExposureIndexProcessorTests : LongTests<RecommendedExposureIndexProcessor>
    {
        public RecommendedExposureIndexProcessorTests()
            : base(0x8832, "RecommendedExposureIndex")
        {}
    }
}