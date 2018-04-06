namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class SensingMethodProcessorTests : EnumTests<SensingMethodProcessor, SensingMethod>
    {
        public SensingMethodProcessorTests()
            : base(x => x.SensingMethod, "/app1/ifd/exif/{ushort=41495}")
        { }
    }
}