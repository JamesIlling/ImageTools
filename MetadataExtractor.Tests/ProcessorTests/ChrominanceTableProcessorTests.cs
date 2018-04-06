namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ChrominanceTableProcessorTests : ArrayOfUshortTests<ChrominanceTableProcessor>
    {
        public ChrominanceTableProcessorTests()
            : base(x => x.ChrominanceTable, "/chrominance/TableEntry")
        { }
    }
}