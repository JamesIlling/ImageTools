namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class LuminanceTableProcessorTests : ArrayOfUshortTests<LuminanceTableProcessor>
    {
        public LuminanceTableProcessorTests()
            : base(x => x.LuminanceTable, "/luminance/TableEntry")
        { }
    }
}