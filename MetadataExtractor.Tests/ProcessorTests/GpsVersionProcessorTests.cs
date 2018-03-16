using System.Windows.Media.Imaging;
using FluentAssertions;
using MetadataExtractor.Processors;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    public class GpsVersionProcessorTests :ProcessorTests<GpsVersionProcessor>
    {
        public GpsVersionProcessorTests()
            :base("/app1/ifd/gps/{ushort=0}")
        {            
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, null);

            var result = metadata.GpsVersion;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNotBitmapMetadataBlob()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, "test");

            var result = metadata.GpsVersion;
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsWrongLength()
        {
            var data =  new byte[]{ 0x01,0x02,0x00};
            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data));

            var result = metadata.GpsVersion;
            result.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var data = new byte[] { 0x01, 0x02, 0x01 ,0x02};
            var metadata = new Metadata();
            Processor.Process(metadata, new BitmapMetadataBlob(data));

            var result = metadata.GpsVersion;
            result.Major.Should().Be(1);
            result.Minor.Should().Be(2);
            result.Build.Should().Be(1);
            result.Revision.Should().Be(2);
        }
    }
}
