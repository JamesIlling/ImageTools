namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class SubjectDistanceProcessorTests : EnumTests<SubjectDistanceProcessor, SubjectDistance>
    {
        public SubjectDistanceProcessorTests()
            : base(x => x.SubjectDistance, "/app1/ifd/exif/{ushort=41996}")
        {}
    }
}