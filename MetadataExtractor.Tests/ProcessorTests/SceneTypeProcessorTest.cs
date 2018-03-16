namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class SceneTypeProcessorTest : BitmapMetadataBlobEnumTests<SceneTypeProcessor, SceneType>
    {
        public SceneTypeProcessorTest()
            : base(x => x.SceneType, "/app1/ifd/exif/{ushort=41729}")
        {}
    }
}