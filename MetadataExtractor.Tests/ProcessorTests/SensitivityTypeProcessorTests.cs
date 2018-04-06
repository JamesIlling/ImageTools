namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using Processors;
    using TestBaseClasses;

    public class SensitivityTypeProcessorTests : EnumTests<SensitivityTypeProcessor, SensitivityType>
    {
        public SensitivityTypeProcessorTests()
            : base(x => x.SensitivityType, "/app1/ifd/exif/{ushort=34864}")
        {}
    }
}