namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class FileSourceProcessorTests : BitmapMetadataBlobEnumTests<FileSourceProcessor, FileSource>
    {
        public FileSourceProcessorTests()
            : base(x => x.FileSource, "/app1/ifd/exif/{ushort=41728}")
        { }
    }
}