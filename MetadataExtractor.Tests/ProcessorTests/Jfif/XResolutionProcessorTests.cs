namespace MetadataExtractor.Tests.ProcessorTests.Jfif
{
    using NUnit.Framework;
    using Processors.Jfif;
    using TestBaseClasses;

    [TestFixture]
    public class XResolutionProcessorTests : DecimalsFromUshortTests<XResolutionProcessor>
    {
        public XResolutionProcessorTests()
            : base(x => x.XResolution, "/app0/{ushort=2}")
        { }
    }
}