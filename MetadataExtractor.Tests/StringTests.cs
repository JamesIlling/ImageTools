namespace MetadataExtractor.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class StringTests<T> : ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        public StringTests(int id, string result)
            : base(id, result)
        { }

        [Test]
        public void MetadataFieldPopulated()
        {
            const string text = "test";
            var value = ExifTypeHelper.CreateString(text);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = Processor.Id, Value = value };

            Processor.Process(metadata, property);

            ((string)metadata.GetType().GetProperty(Result)?.GetValue(metadata)).Should().Be(text);
        }

    }
}
