namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using DependencyFactory;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class StringTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor: ISupportQueries
    {
        private readonly Func<Metadata, string> _getMetadataElement;

        public StringTests(Func<Metadata, string> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void NullTerminatorRemovedFromString()
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, "Test\0");

            var result = _getMetadataElement(metadata);
            result.Should().Be("Test");
        }
    }
}
