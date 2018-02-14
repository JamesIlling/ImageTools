namespace MetadataExtractor.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public abstract class SignedRationalTests<T> : ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        public SignedRationalTests(int id, string result)
            : base(id, result)
        {}


        [Test]
        public void ProcessorThrowExecptionwhenDemoninatorIsZero()
        {
            var value = ExifTypeHelper.CreateSignedRational(1, 0);
            var metadata = new Metadata();
            var property = new ExifProperty { Id = Processor.Id, Value = value };

            Assert.Throws<DivideByZeroException>(() => Processor.Process(metadata, property));
        }

        [Test]
        public void MetadataFieldPopulatedWithNegativeValueDenominator()
        {
            var rational = ExifTypeHelper.CreateSignedRational(4, -8);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = rational};

            Processor.Process(metadata, property);
            ((decimal?) metadata.GetType().GetProperty(Result)?.GetValue(metadata)).Should().Be(-0.5m);
        }

        [Test]
        public void MetadataFieldPopulatedWithNegativeValueNumerator()
        {
            var rational = ExifTypeHelper.CreateSignedRational(-4, 8);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = rational};

            Processor.Process(metadata, property);
            ((decimal?) metadata.GetType().GetProperty(Result)?.GetValue(metadata)).Should().Be(-0.5m);
        }
    }
}