namespace MetadataExtractor.Tests.ProcessorTests

{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class IsoProcessorTests : ShortTests<IsoProcessor>
    {
        public IsoProcessorTests()
            : base(0x8827, "Iso")
        {}
    }
}