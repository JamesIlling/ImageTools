using System;
using FluentAssertions;
using NUnit.Framework;

namespace MetadataExtractor.Tests.TestBaseClasses
{
    public abstract class StringTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
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
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void NullTerminatorRemovedFromString()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, "Test\0");

            var result = _getMetadataElement(metadata);
            result.Should().Be("Test");
        }
    }
}