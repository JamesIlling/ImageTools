namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using DependencyFactory;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class DateTimeSubSecondsTests<TProcessor> : ProcessorTests<TProcessor>
        where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, DateTime?> _getMetadataElement;
        private readonly Action<Metadata, DateTime> _setMetadataElement;

        public DateTimeSubSecondsTests(Func<Metadata, DateTime?> getMetadata, Action<Metadata, DateTime> set,
            string query)
            : base(query)
        {
            _setMetadataElement = set;
            _getMetadataElement = getMetadata;
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();
            _setMetadataElement(metadata, DateTime.Today.ToNearestSecond());
            processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.HasValue.Should().BeTrue();
            result.Value.Millisecond.Should().Be(0);
        }

        [Test]
        public void NoValueStoredIfTimeIsNull()
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();
            processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [TestCase("NotANumber")]
        [TestCase("-100")]
        public void InvalidValueNotWrittenToMetadata(string input)
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();
            _setMetadataElement(metadata, DateTime.Today.ToNearestSecond());
            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.HasValue.Should().BeTrue();
            result.Value.Millisecond.Should().Be(0);
        }

        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("100", 100)]
        public void ValidValueWrittenToMetadata(string input,int value)
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();
            _setMetadataElement(metadata, DateTime.Today.ToNearestSecond());
            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.HasValue.Should().BeTrue();
            result.Value.Millisecond.Should().Be(value);
        }
    }
}