namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailYResolutionProcessorTests : RationalTests<ThumbnailYResolutionProcessor>
    {
        public ThumbnailYResolutionProcessorTests()
            : base(x => x.ThumbnailYResolution, "/app1/thumb/{ushort=283}")
        { }
    }
}