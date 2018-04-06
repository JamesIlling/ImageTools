namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ModifiedDateTimeSubsecondProcessorTests : DateTimeSubSecondsTests<ModifiedDateTimeSubsecondProcessor>
    {
        public ModifiedDateTimeSubsecondProcessorTests()
            : base(x => x.ModifiedTime, (metadata, time) => metadata.ModifiedTime = time, "/app1/ifd/exif/{ushort=37520}")
        { }
    }
}