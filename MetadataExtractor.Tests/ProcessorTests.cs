namespace MetadataExtractor.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        protected IMetaDataElementProcessor Processor { get; }
        private int Id { get; }
        protected string Result { get; }

        protected ProcessorTests(int id, string result)
        {
            Processor = (IMetaDataElementProcessor)DependencyFactory.DependencyInjection.Resolve(typeof(T));
            Id = id;
            Result = result;
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            Processor.Id.Should().Be(Id);
        }

    }
}