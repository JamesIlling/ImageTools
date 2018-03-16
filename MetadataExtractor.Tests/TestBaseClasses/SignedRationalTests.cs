namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class SignedRationalTests<TProcessor> : RationalProcessorTests<TProcessor, long>
        where TProcessor : ISupportQueries
    {
        protected SignedRationalTests(Func<Metadata, decimal?> getMetadataElement, string query)
            : base(getMetadataElement, query)
        {}

        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 0.5)]
        [TestCase(2, 1, 2)]
        [TestCase(int.MaxValue, int.MaxValue, 1)]
        [TestCase(int.MaxValue, 1, int.MaxValue)]
        [TestCase(1, 1, 1)]
        [TestCase(1, -1, -1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, -1, 1)]
        public void ValidValueWrittenToMetadata(int numerator, int denominator, decimal expected)
        {
            var component = BitConverter.GetBytes(numerator).ToList();
            component.AddRange(BitConverter.GetBytes(denominator));
            var input = BitConverter.ToInt64(component.ToArray(), 0);


            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = GetMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}