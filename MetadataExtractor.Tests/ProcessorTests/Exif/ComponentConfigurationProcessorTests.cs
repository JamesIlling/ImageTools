namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Collections;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors.Exif;
    using TestClasses;

    [TestFixture]
    public class ComponentConfigurationProcessorTests : ErrorableProcessorTests<ComponentConfigurationProcessor>
    {
        public ComponentConfigurationProcessorTests()
            : base("/app1/ifd/exif/{ushort=37121}")
        { }

        private static IEnumerable ValidValues()
        {
            return Enum<ComponentConfiguration, byte>.Values()
                .Select(value => new TestCaseData(value, Enum<ComponentConfiguration, byte>.Value(value)));
        }

        private static IEnumerable InvalidValue()
        {
            yield return new TestCaseData(Enum<ComponentConfiguration, byte>.GetInvalidValue());
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(byte input)
        {
            var processor = Processor;
            var testLogger = processor.Log as TestLog;
            Assert.NotNull(testLogger);
            var metadata = new Metadata();
            var data = new BitmapMetadataBlob(new byte[] {input, 0x00, 0x00, 0x00});

            processor.Process(metadata, data);

            testLogger.Messages.Count.Should().Be(1);
            var logEntry = testLogger.Messages.FirstOrDefault();
            Assert.NotNull(logEntry);
            logEntry.Level.Should().Be("Warning");
            logEntry.Message.Should().Be(string.Format(processor.Error, input));
        }

        [Test]
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueNotWrittenToMetadata(byte input)
        {
            var metadata = new Metadata();
            var data = new BitmapMetadataBlob(new byte[] {input, 0x00, 0x00, 0x00});

            Processor.Process(metadata, data);

            var result = metadata.ComponentConfiguration;
            result.Should().BeNull();
        }


        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = metadata.ComponentConfiguration;
            result.Should().BeNull();
        }

        [Test]
        [TestCaseSource(nameof(ValidValues))]
        public void ValidValueWrittenToMetadata(byte input, ComponentConfiguration expected)
        {
            var metadata = new Metadata();
            var data = new BitmapMetadataBlob(new byte[] {input, 0x00, 0x00, 0x00});

            Processor.Process(metadata, data);

            var result = metadata.ComponentConfiguration.First();
            result.Should().Be(expected);
        }
    }
}