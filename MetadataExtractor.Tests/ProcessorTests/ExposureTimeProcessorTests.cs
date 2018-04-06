namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ExposureTimeProcessorTests : RationalTests<ExposureTimeProcessor>
    {
        public ExposureTimeProcessorTests()
            : base(x => x.ExposureTime, "/app1/ifd/exif/{ushort=33434}")
        { }
    }
}