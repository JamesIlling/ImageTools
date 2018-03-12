using System;
using DependencyFactory;
using FluentAssertions;
using NUnit.Framework;

namespace MetadataExtractor.Tests.TestBaseClasses
{
    public abstract class ShortTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, ushort?> _getMetadataElement;

        public ShortTests(Func<Metadata, ushort?> getMetadataElement, string query)
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

        [TestCase((ushort)0, (ushort)0)]
        [TestCase((ushort)1, (ushort)1)]
        [TestCase(ushort.MaxValue, ushort.MaxValue)]
        [TestCase(ushort.MinValue, ushort.MinValue)]
        public void ValidValueWrittenToMetadata(ushort input, ushort? expected)
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}