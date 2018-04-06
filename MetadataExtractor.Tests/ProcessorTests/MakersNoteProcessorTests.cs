namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class MakersNoteProcessorTests : UnsupportedProcessorTests<MakersNoteProcessor>
    {
        public MakersNoteProcessorTests()
            : base("/app1/ifd/exif/{ushort=37500}")
        { }
    }
}