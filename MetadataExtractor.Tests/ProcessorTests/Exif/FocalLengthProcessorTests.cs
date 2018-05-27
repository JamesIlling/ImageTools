namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class FocalLengthProcessorTests : RationalTests<FocalLengthProcessor>
    {
        public FocalLengthProcessorTests()
            : base(x => x.FocalLength, "/app1/ifd/exif/{ushort=37386}")
        { }
    }
}