namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class EditingSoftwareProcessorTests : StringTests<EditingSoftwareProcessor>
    {
        public EditingSoftwareProcessorTests()
            : base(x => x.EditingSoftware, "/app1/ifd/{ushort=305}")
        { }
    }
}