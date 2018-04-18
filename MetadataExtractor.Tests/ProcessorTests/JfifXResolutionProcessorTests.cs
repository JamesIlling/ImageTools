namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifXResolutionProcessorTests : DecimalsFromUshortTests<JfifXResolutionProcessor>
    {
        public JfifXResolutionProcessorTests()
            : base(x => x.XResolution, "/app0/{ushort=2}")
        { }
    }
}