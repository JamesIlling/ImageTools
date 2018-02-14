namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureCompensationProcessorTests : SignedRationalTests<ExposureCompensationProcessor>
    {
        public ExposureCompensationProcessorTests() : base(0x9204, "ExposureCompensation")
        {}
    }
}