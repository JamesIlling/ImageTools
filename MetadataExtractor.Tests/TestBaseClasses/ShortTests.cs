﻿namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class ShortTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, ushort?> _getMetadataElement;

        protected ShortTests(Func<Metadata, ushort?> getMetadataElement, string query)
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
        [TestCase((ushort) 0)]
        [TestCase((ushort) 1)]
        [TestCase(ushort.MaxValue)]
        [TestCase(ushort.MinValue)]
        public void ValidValueWrittenToMetadata(ushort input)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(input);
        }
    }
}