namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ChrominanceTableProcessorTests : ByteArrayTests<ChrominanceTableProcessor>
    {
        public ChrominanceTableProcessorTests()
            : base(0x5091, "ChrominanceTable")
        {}
    }
}