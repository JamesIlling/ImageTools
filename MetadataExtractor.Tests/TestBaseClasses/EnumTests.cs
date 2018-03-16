namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Collections;
    using System.Linq;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using TestClasses;

    public abstract class EnumTests<TProcessor, TEnum> : ErrorableProcessorTests<TProcessor>
        where TProcessor : ISupportErrorableQueries
        where TEnum : struct, IConvertible
    {
        private readonly Func<Metadata, TEnum?> _getMetadataElement;

        protected EnumTests(Func<Metadata, TEnum?> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }


        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueNotWrittenToMetadata(ushort input)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(ushort input)
        {
            var testLogger = Processor.Log as TestLog;
            Assert.NotNull(testLogger);
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            testLogger.Messages.Count.Should().Be(1);
            var logEntry = testLogger.Messages.FirstOrDefault();
            Assert.NotNull(logEntry);
            logEntry.Level.Should().Be("Warning");
            logEntry.Message.Should().Be(string.Format(Processor.Error, input));
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
        [TestCaseSource(nameof(ValidValues))]
        public void ValidValueWrittenToMetadata(ushort input, TEnum? expected)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }

        public static IEnumerable ValidValues()
        {
            return Enum<TEnum, ushort>.Values()
                .Select(value => new TestCaseData(value, Enum<TEnum, ushort>.Value(value)));
        }

        public static IEnumerable InvalidValue()
        {
            yield return new TestCaseData(Enum<TEnum, ushort>.GetInvalidValue());
        }
    }
}