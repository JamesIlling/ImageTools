namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class SensitivityTypeProcessorTests : EnumTests<SensitivityTypeProcessor, SensitivityType>
    {
        public SensitivityTypeProcessorTests()
            : base(x => x.SensitivityType, "/app1/ifd/exif/{ushort=34864}")
        { }
    }
}