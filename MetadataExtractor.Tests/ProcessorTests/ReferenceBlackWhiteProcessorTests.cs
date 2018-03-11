namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ReferenceBlackWhiteProcessorTests : RationalTests<ReferenceBlackWhiteProcessor>
    {
        public ReferenceBlackWhiteProcessorTests()
            : base(x => x.ReferenceBlackWhite, "/app1/ifd/{uint=532}")
        {}
    }
}