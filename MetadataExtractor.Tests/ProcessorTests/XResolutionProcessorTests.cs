namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class XResolutionProcessorTests : RationalTests<XResolutionProcessor>
    {
        public XResolutionProcessorTests()
            : base(x => x.XResolution, "/app1/ifd/{ushort=282}")
        {}
    }
}