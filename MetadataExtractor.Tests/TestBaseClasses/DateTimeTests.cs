namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class DateTimeTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private const string Format = "yyyy:MM:dd HH:mm:ss";
        private readonly Func<Metadata, DateTime?> _getMetadataElement;

        protected DateTimeTests(Func<Metadata, DateTime?> getMetadata, string query)
            : base(query)
        {
            _getMetadataElement = getMetadata;
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
        public void InvalidValueNotWrittenToMetadata()
        {
            var input = DateTime.UtcNow.ToNearestSecond().ToString("U");
            
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var expected =DateTime.UtcNow.ToNearestSecond();

            var input = expected.ToString(Format);
            
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}