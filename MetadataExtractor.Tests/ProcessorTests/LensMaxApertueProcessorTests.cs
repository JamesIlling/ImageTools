namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class LensMaxApertueProcessorTests : RationalTests<LensMaxApertueProcessor>
    {
        public LensMaxApertueProcessorTests()
            : base(x => x.LensMaxAperture, "/app1/ifd/exif/{ushort=37381}")
        {}
    }
}