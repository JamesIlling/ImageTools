using MetadataExtractor.Processors;
using MetadataExtractor.Tests.TestBaseClasses;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    [TestFixture]
    public class IsoProcessorTests : ShortTests<IsoProcessor>
    {
        public IsoProcessorTests()
            :base(x => x.Iso, "/app1/ifd/exif/{ushort=34855}")
        {
            
        }
    }
}
