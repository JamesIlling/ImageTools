namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class DescriptionProcessorTests : StringTests<DescriptionProcessor>
    {
        public DescriptionProcessorTests()
            : base(0x010E, "Description")
        {}
    }
}