namespace MetadataExtractor.Tests.ProcessorTests.Xmp
{
    using NUnit.Framework;
    using Processors.Xmp;
    using TestBaseClasses;

    [TestFixture]
    public class EditingSoftwareProcessorTests : StringTests<EditingSoftwareProcessor>
    {
        public EditingSoftwareProcessorTests()
            : base(x => x.EditingSoftware, "/xmp/xmp:CreatorTool")
        { }
    }
}