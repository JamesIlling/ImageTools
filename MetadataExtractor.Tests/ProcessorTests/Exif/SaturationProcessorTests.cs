namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class SaturationProcessorTests : EnumTests<SaturationProcessor, Saturation>

    {
        public SaturationProcessorTests()
            : base(x => x.Saturation, "/app1/ifd/exif/{ushort=41993}")
        { }
    }
}