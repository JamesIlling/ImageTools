namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneYResolutionProcessorTests : RationalTests<FocalPlaneYResolutionProcessor>
    {
        public FocalPlaneYResolutionProcessorTests()
            : base(0xA20F, "FocalPlaneYResolution")
        {}
    }
}