namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class DigitalZoomRatioProcessorTests : RationalTests<DigitalZoomRatioProcessor>
    {
        public DigitalZoomRatioProcessorTests()
            : base(x => x.DigitalZoomRatio, "/app1/ifd/exif/{ushort=41988}")
        { }
    }
}