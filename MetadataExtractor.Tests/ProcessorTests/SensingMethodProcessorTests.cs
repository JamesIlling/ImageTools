namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class SensingMethodProcessorTests : EnumTests<SensingMethodProcessor, SensingMethodEnum, ushort>
    {
        public SensingMethodProcessorTests()
            : base(x => x.SensingMethod, "/app1/ifd/exif/{ushort=41495}")
        {}
    }
}