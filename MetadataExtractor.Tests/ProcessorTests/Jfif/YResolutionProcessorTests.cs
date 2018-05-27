namespace MetadataExtractor.Tests.ProcessorTests.Jfif
{
    using NUnit.Framework;
    using Processors.Jfif;
    using TestBaseClasses;

    [TestFixture]
    public class YResolutionProcessorTests : DecimalsFromUshortTests<YResolutionProcessor>
    {
        public YResolutionProcessorTests()
            : base(x => x.YResolution, "/app0/{ushort=3}")
        { }
    }
}