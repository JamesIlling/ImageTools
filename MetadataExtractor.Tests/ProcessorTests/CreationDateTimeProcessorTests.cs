namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CreationDateTimeProcessorTests : DateTimeTests<CreationDateTimeProcessor>
    {
        public CreationDateTimeProcessorTests()
            : base(x => x.CreationTime, "/app1/ifd/exif/{ushort=36868}")
        { }
    }
}