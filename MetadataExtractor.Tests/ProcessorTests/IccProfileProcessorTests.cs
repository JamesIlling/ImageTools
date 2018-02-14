namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class IccProfileProcessorTests : ByteArrayTests<IccProfileProcessor>
    {
        public IccProfileProcessorTests()
            : base(0x8773, "IccProfile")
        {}
    }
}