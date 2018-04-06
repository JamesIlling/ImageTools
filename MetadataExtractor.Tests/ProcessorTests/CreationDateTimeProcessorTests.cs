namespace MetadataExtractor.Tests.ProcessorTests
{
    using Processors;
    using TestBaseClasses;

    public class CreationDateTimeProcessorTests : DateTimeTests<CreationDateTimeProcessor>
    {
        public CreationDateTimeProcessorTests()
            : base(x => x.CreationTime, "/app1/ifd/exif/{ushort=36868}")
        {}
    }
}