namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneXResolutionProcessorTests : RationalTests<FocalPlaneXResolutionProcessor>
    {
        public FocalPlaneXResolutionProcessorTests()
            : base(0xA20E, "FocalPlaneXResolution")
        {}
    }
}