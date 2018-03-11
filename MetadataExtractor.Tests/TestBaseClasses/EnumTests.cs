namespace MetadataExtractor.Tests
{
    using System;
    using System.Collections;
    using System.Linq;
    using DependencyFactory;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using TestClasses;

    public abstract class EnumTests<TProcessor, TEnum, TBase> : ProcessorTests<TProcessor>
        where TProcessor : ISupportErrorableQueries
        where TEnum : struct, IConvertible
    {
        private readonly Func<Metadata, Nullable<TEnum>> _getMetadataElement;

        public EnumTests(Func<Metadata, Nullable<TEnum>> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }


        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueNotWrittenToMetadata(TBase input, TEnum? expected)
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(TBase input, TEnum? expected)
        {
            var processor = DependencyInjection.Resolve<TProcessor>() as ISupportErrorableQueries;
            var testLogger = processor?.Log as TestLog;

            var metadata = new Metadata();

            processor.Process(metadata, input);

            processor.Should().NotBeNull();
            testLogger.Should().NotBeNull();
            testLogger.Messages.Count.Should().Be(1);
            var logEntry = testLogger.Messages.FirstOrDefault();
            logEntry.Should().NotBeNull();
            logEntry.Level.Should().Be("Warning");
            logEntry.Message.Should().Be(string.Format(processor.Error, input));
        }

        [Test]
        [TestCaseSource(nameof(ValidValues))]
        public void ValidValueWrittenToMetadata(TBase input, TEnum? expected)
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }

        [Test]
        public void ErrorMessageContainsTypeName()
        {
            var processor = DependencyInjection.Resolve<TProcessor>();

            var name = processor.GetType().Name.Replace("Processor", "");
            var toreplace = name.Where(char.IsUpper);
            name =
                toreplace.Aggregate(name, (current, item) => current.Replace(item.ToString(), " " + char.ToLower(item)))
                    .Trim();

            var error = $"Unknown {name} value:{{0:X4}}";
            processor.Error.Should().Be(error);
        }

        public static IEnumerable ValidValues()
        {
            return Enum<TEnum, TBase>.Values().Select(value => new TestCaseData(value, Enum<TEnum, TBase>.Value(value)));
        }

        public static IEnumerable InvalidValue()
        {
            yield return new TestCaseData(Enum<TEnum, TBase>.GetInvalidValue(), null);
        }
    }
}