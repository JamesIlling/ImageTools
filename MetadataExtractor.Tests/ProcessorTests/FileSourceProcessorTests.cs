namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class FileSourceProcessorTests : BitmapMetadataBlobEnumTests<FileSourceProcessor, FileSourceEnum>
    {
        public FileSourceProcessorTests()
            : base(x => x.FileSource, "/app1/ifd/exif/{ushort=41728}")
        {}
    }
}