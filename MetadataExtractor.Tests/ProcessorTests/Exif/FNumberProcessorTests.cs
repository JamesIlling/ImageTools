namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class FNumberProcessorTests : RationalTests<FNumberProcessor>
    {
        public FNumberProcessorTests()
            : base(x => x.FNumber, "/app1/ifd/exif/{ushort=33437}")
        { }
    }
}