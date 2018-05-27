namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class ShutterSpeedApexProcessorTests : SignedRationalTests<ShutterSpeedApexProcessor>
    {
        public ShutterSpeedApexProcessorTests()
            : base(x => x.ShutterSpeedApexValue, "/app1/ifd/exif/{ushort=37377}")
        { }
    }
}