namespace MetadataExtractor.Tests.ProcessorTests
{
    using Processors;
    using TestBaseClasses;

    public class ModifiedDateTimeProcessorTests : DateTimeTests<ModifiedDateTimeProcessor>
    {
        public ModifiedDateTimeProcessorTests()
            : base(x => x.ModifiedTime, "/app1/ifd/{ushort=306}")
        {}
    }
}