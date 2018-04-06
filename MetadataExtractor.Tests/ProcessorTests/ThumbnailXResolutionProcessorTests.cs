namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailXResolutionProcessorTests : RationalTests<ThumbnailXResolutionProcessor>
    {
        public ThumbnailXResolutionProcessorTests()
            : base(x => x.ThumbnailXResolution, "/app1/thumb/{ushort=282}")
        {}
    }
}