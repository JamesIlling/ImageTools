namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CopyrightProcessorTests : StringTests<CopyrightProcessor>
    {
        public CopyrightProcessorTests()
            : base(0x8298, "Copyright")
        {}
    }
}