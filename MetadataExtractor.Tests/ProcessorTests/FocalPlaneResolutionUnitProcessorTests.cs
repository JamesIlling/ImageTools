namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class FocalPlaneResolutionUnitProcessorTests :
        EnumTests<FocalPlaneResolutionUnitProcessor, ResolutionUnit>
    {
        public FocalPlaneResolutionUnitProcessorTests()
            : base(x => x.FocalPlaneResolutionUnit, "/app1/ifd/exif/{ushort=41488}")
        {}
    }
}