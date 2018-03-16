namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class SignedRationalTests<TProcessor> : ProcessorTests<TProcessor>
        where TProcessor : ISupportQueries
    {
        private readonly Func<Metadata, decimal?> _getMetadataElement;

        protected SignedRationalTests(Func<Metadata, decimal?> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }

        [Test]
        public void ExceptionThrownIfDenominatorIsZero()
        {
            const long input = 0L;
         
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

        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 0.5)]
        [TestCase(2, 1, 2)]
        [TestCase(int.MaxValue, int.MaxValue, 1)]
        [TestCase(int.MaxValue, 1, int.MaxValue)]
        public void ValidValueWrittenToMetadata(int numerator, int denominator, decimal expected)
        {
            var component = BitConverter.GetBytes(numerator).ToList();
            component.AddRange(BitConverter.GetBytes(denominator));
            var input = BitConverter.ToInt64(component.ToArray(), 0);


            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }


        [TestCase(1, 1, 1)]
        [TestCase(1, -1, -1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, -1, 1)]
        public void SignsCancelOutCorrectly(int numerator, int denominator, decimal? expected)
        {
            var component = BitConverter.GetBytes(numerator).ToList();
            component.AddRange(BitConverter.GetBytes(denominator));
            var input = BitConverter.ToInt64(component.ToArray(), 0);

            
            var metadata = new Metadata();

           Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }
    }
}