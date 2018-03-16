using MetadataExtractor.Tests.TestBaseClasses;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class SubjectDistanceProcessorTests : EnumTests<SubjectDistanceProcessor, SubjectDistanceEnum, ushort>
    {
        public SubjectDistanceProcessorTests()
            : base(x => x.SubjectDistance, "/app1/ifd/exif/{ushort=41996}")
        {}
    }
}