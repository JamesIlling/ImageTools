namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class CustomRenderingProcessorTests : EnumTests<CustomRenderingProcessor, CustomRendering>
    {
        public CustomRenderingProcessorTests()
            : base(x => x.CustomRendering, "/app1/ifd/exif/{ushort=41985}")
        { }
    }
}