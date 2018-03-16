namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class RationalProcessorTests<TProcessor, T> : ProcessorTests<TProcessor> where TProcessor : ISupportQueries
    {
        protected readonly Func<Metadata, decimal?> GetMetadataElement;

        protected RationalProcessorTests(Func<Metadata, decimal?> getMetadataElement, string query)
            : base(query)
        {
            GetMetadataElement = getMetadataElement;
        }

        [Test]
        public void ExceptionThrownIfDenominatorIsZero()
        {
            var input = default(T);
            var metadata = new Metadata();
            Assert.Throws(typeof(DivideByZeroException), () => Processor.Process(metadata, input));
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = GetMetadataElement(metadata);
            result.Should().BeNull();
        }
    }
}