namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class LensModelProcessorTests : StringTests<LensModelProcessor>
    {
        public LensModelProcessorTests()
            : base(x => x.Lens, "/app1/ifd/exif/{ushort=42036}")
        { }
    }
}