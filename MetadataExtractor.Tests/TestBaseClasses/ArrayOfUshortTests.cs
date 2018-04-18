namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class ArrayOfUshortTests<T> : ProcessorTests<T> where T : ISupportQueries
    {
        private readonly Func<Metadata, ushort[]> _getMetadata;

        protected ArrayOfUshortTests(Func<Metadata, ushort[]> getMetadata, string query)
            : base(query)
        {
            _getMetadata = getMetadata;
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = _getMetadata(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNotArrayOfUshort()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, string.Empty);

            var result = _getMetadata(metadata);
            result.Should().BeNull();
        }

        [Test]
        [TestCase((ushort) 1, (ushort) 2, (ushort) 3)]
        [TestCase(ushort.MaxValue, ushort.MinValue, ushort.MaxValue)]
        public void ValidValueWrittenToMetadata(params ushort[] input)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadata(metadata);
            result.Should().BeEquivalentTo(input);
        }
    }
}