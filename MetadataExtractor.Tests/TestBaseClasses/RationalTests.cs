namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class RationalTests<TProcessor> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, decimal?> _getMetadataElement;

        protected RationalTests(Func<Metadata, decimal?> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }

        [Test]
        public void ExceptionThrownIfDenominatorIsZero()
        {
            const ulong input = 0ul;
            var metadata = new Metadata();
            Assert.Throws(typeof(DivideByZeroException), () => Processor.Process(metadata, input));
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

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

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}