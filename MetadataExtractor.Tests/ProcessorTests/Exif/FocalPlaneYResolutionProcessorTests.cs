namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class FocalPlaneYResolutionProcessorTests : RationalTests<FocalPlaneYResolutionProcessor>
    {
        public FocalPlaneYResolutionProcessorTests()
            : base(x => x.FocalPlaneYResolution, "/app1/ifd/exif/{ushort=41487}")
        { }
    }
}