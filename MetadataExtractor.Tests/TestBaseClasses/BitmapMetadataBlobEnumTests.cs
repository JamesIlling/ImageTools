namespace MetadataExtractor.Tests.TestBaseClasses
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using TestClasses;

    public abstract class BitmapMetadataBlobEnumTests<TProcessor, TEnum> : ErrorableProcessorTests<TProcessor>
        where TProcessor : ISupportErrorableQueries
        where TEnum : struct, IConvertible
    {
        private readonly Func<Metadata, TEnum?> _getMetadataElement;

        protected BitmapMetadataBlobEnumTests(Func<Metadata, TEnum?> getMetadataElement, string query)
            : base(query)
        {
            _getMetadataElement = getMetadataElement;
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueNotWrittenToMetadata(BitmapMetadataBlob input)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().BeNull();
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(BitmapMetadataBlob input)
        {
            var testLogger = Processor.Log as TestLog;
            var metadata = new Metadata();
            Assert.NotNull(testLogger);

            Processor.Process(metadata, input);

            testLogger.Messages.Count.Should().Be(1);
            var logEntry = testLogger.Messages.FirstOrDefault();
            Assert.NotNull(logEntry);
            logEntry.Level.Should().Be("Warning");
            logEntry.Message.Should().Be(string.Format(Processor.Error, input.GetBlobValue().FirstOrDefault()));
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
        public void ValidValueWrittenToMetadata(BitmapMetadataBlob input, TEnum? expected)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, input);

            var result = _getMetadataElement(metadata);
            result.Should().Be(expected);
        }

        public static IEnumerable ValidValues()
        {
            return Enum<TEnum, byte>.Values().Select(value => new TestCaseData(new BitmapMetadataBlob(new[] {value}), Enum<TEnum, byte>.Value(value)));
        }

        public static IEnumerable InvalidValue()
        {
            yield return new TestCaseData(new BitmapMetadataBlob(new[] {Enum<TEnum, byte>.GetInvalidValue()}));
        }
    }
}