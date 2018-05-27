namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class ModifiedDateTimeProcessorTests : DateTimeTests<ModifiedDateTimeProcessor>
    {
        public ModifiedDateTimeProcessorTests()
            : base(x => x.ModifiedTime, "/app1/ifd/{ushort=306}")
        { }
    }
}