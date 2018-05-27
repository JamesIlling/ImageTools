namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class FocalPlaneXResolutionProcessorTests : RationalTests<FocalPlaneXResolutionProcessor>
    {
        public FocalPlaneXResolutionProcessorTests()
            : base(x => x.FocalPlaneXResolution, "/app1/ifd/exif/{ushort=41486}")
        { }
    }
}