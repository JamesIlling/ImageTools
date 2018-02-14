namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalLength35MmEquivalentProcessorTests : ShortTests<FocalLength35MmEquivalentProcessor>
    {
        public FocalLength35MmEquivalentProcessorTests()
            : base(0xa405, "FocalLengthIn35MmFormat")
        {}
    }
}