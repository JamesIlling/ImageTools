using System;
using DependencyFactory;
using FluentAssertions;
using NUnit.Framework;

namespace MetadataExtractor.Tests.TestBaseClasses
{
    public abstract class LongTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, uint?> _getMetadataElement;

        public LongTests(Func<Metadata, uint?> getMetadataElement, string query)
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

        [TestCase(0u, 0u)]
        [TestCase(1u, 1u)]
        [TestCase(uint.MaxValue, uint.MaxValue)]
        [TestCase(uint.MinValue, uint.MinValue)]
        public void ValidValueWrittenToMetadata(uint input, uint? expected)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}