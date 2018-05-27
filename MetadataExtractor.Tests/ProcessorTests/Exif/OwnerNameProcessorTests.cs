namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class OwnerNameProcessorTests : StringTests<OwnerNameProcessor>
    {
        public OwnerNameProcessorTests()
            : base(x => x.Owner, "/app1/ifd/exif/{ushort=42032}")
        { }
    }
}