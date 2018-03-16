namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class DateTimeSubSecondsTests<TProcessor> : ProcessorTests<TProcessor>
        where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, DateTime?> _getMetadataElement;
        private readonly Action<Metadata, DateTime> _setMetadataElement;

        protected DateTimeSubSecondsTests(Func<Metadata, DateTime?> getMetadata, Action<Metadata, DateTime> set,
            string query)
            : base(query)
        {
            _setMetadataElement = set;
            _getMetadataElement = getMetadata;
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();
            _setMetadataElement(metadata, DateTime.Today.ToNearestSecond());
            Processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.HasValue.Should().BeTrue();
            result?.Millisecond.Should().Be(0);
        }

        [Test]
        public void NoValueStoredIfTimeIsNull()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [TestCase("NotANumber")]
        [TestCase("-100")]
        public void InvalidValueNotWrittenToMetadata(string input)
        {
            var metadata = new Metadata();
            _setMetadataElement(metadata, DateTime.Today.ToNearestSecond());
            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.HasValue.Should().BeTrue();
            result?.Millisecond.Should().Be(0);
        }

        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("100", 100)]
        public void ValidValueWrittenToMetadata(string input, int value)
        {
            var metadata = new Metadata();
            _setMetadataElement(metadata, DateTime.Today.ToNearestSecond());
            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.HasValue.Should().BeTrue();
            result?.Millisecond.Should().Be(value);
        }
    }
}