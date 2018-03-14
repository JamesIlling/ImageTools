namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using DependencyFactory;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class DateTimeTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private const string Format = "yyyy:MM:dd HH:mm:ss";
        private readonly Func<Metadata, DateTime?> _getMetadataElement;

        public DateTimeTests(Func<Metadata, DateTime?> getMetadata, string query)
            : base(query)
        {
            _getMetadataElement = getMetadata;
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
        public void InvalidValueNotWrittenToMetadata()
        {
            var input = DateTime.UtcNow.ToNearestSecond().ToString("U");
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var expected =DateTime.UtcNow.ToNearestSecond();

            var input = expected.ToString(Format);
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}