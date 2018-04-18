namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifThumbnailProcessorTests : UnsupportedProcessorTests<JfifThumbnailProcessor>
    {
        public JfifThumbnailProcessorTests()
            : base("/app0/{ushort=6}")
        { }
    }
}