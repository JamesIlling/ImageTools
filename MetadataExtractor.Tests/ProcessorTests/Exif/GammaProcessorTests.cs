namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class GammaProcessorTests : RationalTests<GammaProcessor>
    {
        public GammaProcessorTests()
            : base(x => x.Gamma, "/app1/ifd/exif/{ushort=42240}")
        { }
    }
}