namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class EditingSoftwareProcessorTests : StringTests<EditingSoftwareProcessor>
    {
        public EditingSoftwareProcessorTests()
            : base(0x0131, "EditingSoftware")
        {}
    }
}