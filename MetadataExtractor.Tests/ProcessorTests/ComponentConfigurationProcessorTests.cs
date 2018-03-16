using System.Collections;
using System.Linq;
using System.Windows.Media.Imaging;
using FluentAssertions;
using MetadataExtractor.Enums;
using MetadataExtractor.Processors;
using MetadataExtractor.Tests.Logging;
using MetadataExtractor.Tests.TestClasses;
using NUnit.Framework;

namespace MetadataExtractor.Tests.ProcessorTests
{
    public class ComponentConfigurationProcessorTests : ProcessorTests<ComponentConfigurationProcessor>
    {
        public ComponentConfigurationProcessorTests()
            : base("/app1/ifd/exif/{ushort=37121}")
        {
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
        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(byte input)
        {
            var processor = Processor as ISupportErrorableQueries;
            processor.Should().NotBeNull();
            var testLogger = processor.Log as TestLog;
            testLogger.Should().NotBeNull();
            var metadata = new Metadata();
            var data = new BitmapMetadataBlob(new byte[] {input, 0x00, 0x00, 0x00});

            processor.Process(metadata, data);

            testLogger.Messages.Count.Should().Be(1);
            var logEntry = testLogger.Messages.FirstOrDefault();
            logEntry.Should().NotBeNull();
            logEntry.Level.Should().Be("Warning");
            logEntry.Message.Should().Be(string.Format(processor.Error, input));
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
        public void ValidValueWrittenToMetadata(byte input, ComponentConfigurationEnum expected)
        {
            var metadata = new Metadata();
            var data = new BitmapMetadataBlob(new byte[] {input, 0x00, 0x00, 0x00});

            Processor.Process(metadata, data);

            var result = metadata.ComponentConfiguration.First();
            result.Should().Be(expected);
        }

        [Test]
        public void ErrorMessageContainsTypeName()
        {
            var processor = Processor as ISupportErrorableQueries;

            var name = NameUtils.GetNameFromProcessor(processor);
            var error = $"Unknown {name} value:{{0:X4}}";
            processor.Error.Should().Be(error);
        }

        public static IEnumerable ValidValues()
        {
            return Enum<ComponentConfigurationEnum, byte>.Values()
                .Select(value => new TestCaseData(value, Enum<ComponentConfigurationEnum, byte>.Value(value)));
        }

        public static IEnumerable InvalidValue()
        {
            yield return new TestCaseData(Enum<ComponentConfigurationEnum, byte>.GetInvalidValue());
        }
    }
}