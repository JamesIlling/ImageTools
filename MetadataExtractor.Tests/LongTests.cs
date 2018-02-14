namespace MetadataExtractor.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class LongTests<T> : ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        public LongTests(int id, string result)
            : base(id, result)
        {}

        [Test]
        public void MetadataFieldPopulated()
        {
            const uint value = 0x42424242;
            var shortValue = ExifTypeHelper.GetLong(value);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = shortValue};

            Processor.Process(metadata, property);
            var propertyValue = metadata.GetType().GetProperty(Result)?.GetValue(metadata);
            if (propertyValue != null)
            {
                ((uint) propertyValue).Should().Be(value);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}