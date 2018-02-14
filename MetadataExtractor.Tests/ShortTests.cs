namespace MetadataExtractor.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class ShortTests<T> : ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        public ShortTests(int id, string result)
            : base(id, result)
        {}

        [Test]
        public void MetadataFieldPopulated()
        {
            const ushort value = 0x0001;
            var shortValue = ExifTypeHelper.GetShort(value);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = shortValue};

            Processor.Process(metadata, property);
            var propertyValue = metadata.GetType().GetProperty(Result)?.GetValue(metadata);
            if (propertyValue != null)
            {
                ((uint) propertyValue).Should().Be(Convert.ToUInt32(value));
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}