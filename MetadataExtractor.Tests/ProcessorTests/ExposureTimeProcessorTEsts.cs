namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureTimeProcessorTests : RationalTests<ExposureTimeProcessor>
    {
        public ExposureTimeProcessorTests()
            : base(0x829A, "ExposureTime")
        {}
    }
}