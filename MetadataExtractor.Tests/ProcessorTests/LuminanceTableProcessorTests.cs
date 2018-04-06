namespace MetadataExtractor.Tests.ProcessorTests
{
    using Processors;
    using TestBaseClasses;

    public class LuminanceTableProcessorTests : ArrayOfUshortTests<LuminanceTableProcessor>
    {
        public LuminanceTableProcessorTests()
            : base(x => x.LuminanceTable, "/luminance/TableEntry")
        {}
    }
}