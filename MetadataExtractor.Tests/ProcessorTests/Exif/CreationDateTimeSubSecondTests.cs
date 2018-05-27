namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class CreationDateTimeSubSecondTests : DateTimeSubSecondsTests<CreationDateTimeSubsecondProcessor>
    {
        public CreationDateTimeSubSecondTests()
            : base(x => x.CreationTime, (metadata, date) => metadata.CreationTime = date, "/app1/ifd/exif/{ushort=37522}")
        { }
    }
}