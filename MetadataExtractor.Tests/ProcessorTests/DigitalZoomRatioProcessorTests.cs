namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class DigitalZoomRatioProcessorTests : RationalTests<DigitalZoomRatioProcessor>
    {
        public DigitalZoomRatioProcessorTests()
            : base(0xA404, "DigitalZoomRatio")
        {}
    }
}