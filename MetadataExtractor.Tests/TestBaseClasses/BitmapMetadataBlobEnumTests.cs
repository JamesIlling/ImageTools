namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Windows.Media.Imaging;
    using DependencyFactory;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using TestClasses;

    public abstract class BitmapMetadataBlobEnumTests<TProcessor, TEnum> : ProcessorTests<TProcessor>
        where TProcessor : ISupportErrorableQueries
        where TEnum : struct, IConvertible
    {

        private readonly Func<Metadata, TEnum?> _getMetadataElement;

        public BitmapMetadataBlobEnumTests(Func<Metadata, TEnum?> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueNotWrittenToMetadata(BitmapMetadataBlob input, TEnum? expected)
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(BitmapMetadataBlob input, TEnum? expected)
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
            logEntry.Message.Should().Be(string.Format(processor.Error, input.GetBlobValue().FirstOrDefault()));
        }


        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var processor = DependencyInjection.Resolve<TProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, null);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        [TestCaseSource(nameof(ValidValues))]
        public void ValidValueWrittenToMetadata(BitmapMetadataBlob input, TEnum? expected)
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
            return Enum<TEnum, byte>.Values().Select(value => new TestCaseData(new BitmapMetadataBlob(new[] { value}), Enum<TEnum, byte>.Value(value)));
        }

        public static IEnumerable InvalidValue()
        {
            yield return new TestCaseData(new BitmapMetadataBlob(new[] { Enum<TEnum, byte>.GetInvalidValue()}), null);
        }
    }
}
