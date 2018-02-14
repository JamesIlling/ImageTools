namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExifVersionProcessorTests : StringTests<ExifVersionProcessor>
    {
        public ExifVersionProcessorTests()
            : base(0x9000, "ExifVersion")
        {}
    }
}