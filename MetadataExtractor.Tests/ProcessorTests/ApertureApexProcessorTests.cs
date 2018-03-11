namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ApertureApexProcessorTests : RationalTests<ApertureApexProcessor>
    {
        public ApertureApexProcessorTests()
            : base(x => x.ApertureApexValue, "/app1/ifd/exif/{ushort=37378}")
        {}
    }
}