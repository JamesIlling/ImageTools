namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ExposureCompensationProcessorTest : SignedRationalTests<ExposureCompensationProcessor>
    {
        public ExposureCompensationProcessorTest()
            : base(x => x.ExposureCompensation, "/app1/ifd/exif/{ushort=37380}")
        {}
    }
}