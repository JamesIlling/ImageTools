using System;

namespace MetadataExtractor.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using ProcessorTests;

    public abstract class RationalTests<T> : ProcessorTests<T> where T : IMetaDataElementProcessor
    {
        public RationalTests(int id, string result)
            : base(id, result)
        {}

        [Test]
        public void MetadataFieldPopulated()
        {
            var rational = ExifTypeHelper.CreateRational(4, 8);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = rational};

            Processor.Process(metadata, property);
            ((decimal?) metadata.GetType().GetProperty(Result)?.GetValue(metadata)).Should().Be(0.5m);
        }

        [Test]
        public void ProcessorThrowExecptionwhenDemoninatorIsZero()
        {
            var value = ExifTypeHelper.CreateRational(1, 0);
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = value};

            Assert.Throws<DivideByZeroException>(() => Processor.Process(metadata, property));
        }
    }
}