namespace MetadataExtractor.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class ByteArrayTests<T> : ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        public ByteArrayTests(int id, string result)
            : base(id, result)
        {}

        [Test]
        public void MetadataFieldPopulated()
        {
            var value = new byte[] {0x01, 0x02, 0x03};
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = value};

            Processor.Process(metadata, property);
            var propertyValue = metadata.GetType().GetProperty(Result)?.GetValue(metadata);
            if (propertyValue != null)
            {
                ((byte[]) propertyValue).Should().BeEquivalentTo(value);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}