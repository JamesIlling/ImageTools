using MetadataExtractor.Tests.TestBaseClasses;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CustomRenderingProcessorTests : EnumTests<CustomRenderingProcessor, CustomRenderingEnum, ushort>
    {
        public CustomRenderingProcessorTests()
            : base(x => x.CustomRendering, "/app1/ifd/exif/{ushort=41985}")
        {}
    }
}