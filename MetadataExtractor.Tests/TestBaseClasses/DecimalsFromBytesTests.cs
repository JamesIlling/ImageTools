namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class DecimalsFromBytesTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, decimal?> _getMetadataElement;

        protected DecimalsFromBytesTests(Func<Metadata, decimal?> getMetadataElement, string query)
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

        [TestCase((byte) 0)]
        [TestCase((byte) 1)]
        [TestCase(byte.MaxValue)]
        [TestCase(byte.MinValue)]
        public void ValidValueWrittenToMetadata(byte input)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(Convert.ToDecimal(input));
        }
    }
}