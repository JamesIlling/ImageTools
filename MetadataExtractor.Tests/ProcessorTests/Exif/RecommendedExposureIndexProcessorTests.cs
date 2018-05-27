namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class RecommendedExposureIndexProcessorTests : LongTests<RecommendedExposureIndexProcessor>
    {
        public RecommendedExposureIndexProcessorTests()
            : base(x => x.RecommendedExposureIndex, "/app1/ifd/exif/{ushort=34866}")
        { }
    }
}