namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailProcessorTests : UnsupportedProcessorTests<ThumbnailProcessor>
    {
        public ThumbnailProcessorTests()
            : base("/app1/thumb/{}")
        { }
    }
}