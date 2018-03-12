using MetadataExtractor.Processors;
using MetadataExtractor.Tests.TestBaseClasses;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    [TestFixture]
    public class RecommendedExposureIndexProcessorTests : LongTests<RecommendedExposureIndexProcessor>
    {
        public RecommendedExposureIndexProcessorTests()
            :base(x=>x.RecommendedExposureIndex, "/app1/ifd/exif/{ushort=34866}")
        {
            
        }
    }
}