namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FocalPlaneResolutionUnitProcessorTests :
        EnumTests<FocalPlaneResolutionUnitProcessor, ResolutionUnitEnum, ushort>
    {
        public FocalPlaneResolutionUnitProcessorTests()
            : base(x => x.FocalPlaneResolutionUnit, "/app1/ifd/exif/{ushort=41488}")
        {}
    }
}