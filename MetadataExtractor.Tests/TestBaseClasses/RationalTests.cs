namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class RationalTests<TProcessor> : RationalProcessorTests<TProcessor, ulong> where TProcessor : ISupportQueries
    {
        protected RationalTests(Func<Metadata, decimal?> getMetadataElement, string query)
            : base(getMetadataElement, query)
        {}

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
            var input = BitConverter.ToUInt64(component.ToArray(), 0);

            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = GetMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}