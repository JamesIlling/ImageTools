namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class ArrayOfRationalTests<T> : ProcessorTests<T> where T : ISupportQueries
    {
        private readonly Func<Metadata, decimal?[]> _getMetadata;

        protected ArrayOfRationalTests(Func<Metadata, decimal?[]> getMetadata, string query)
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
        [TestCase(1u, 1u, 1)]
        [TestCase(1u, 2u, 0.5)]
        [TestCase(2u, 1u, 2)]
        [TestCase(uint.MaxValue, uint.MaxValue, 1)]
        [TestCase(uint.MaxValue, 1u, 4294967295d)]
        [TestCase(uint.MinValue, uint.MaxValue, 0)]
        public void ValidValueWrittenToMetadata(uint numerator, uint denominator, decimal? expected)
        {
            var component = BitConverter.GetBytes(numerator).ToList();
            component.AddRange(BitConverter.GetBytes(denominator));
            var input = new[] {BitConverter.ToUInt64(component.ToArray(), 0)};

            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadata(metadata).First();
            result.Should().Be(expected);
        }
    }
}