namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifYResolutionProcessorTests : DecimalsFromUshortTests<JfifYResolutionProcessor>
    {
        public JfifYResolutionProcessorTests()
            : base(x => x.YResolution, "/app0/{ushort=3}")
        { }
    }
}