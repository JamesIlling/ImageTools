namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class DescriptionProcessorTests : StringTests<DescriptionProcessor>
    {
        public DescriptionProcessorTests()
            : base(x => x.Description, "/app1/ifd/{ushort=270}")
        {}
    }
}