namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class YResolutionProcessorTests : RationalTests<YResolutionProcessor>
    {
        public YResolutionProcessorTests()
            : base(x => x.YResolution, "/app1/ifd/{ushort=283}")
        {}
    }
}