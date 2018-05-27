namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors.Exif;
    using TestBaseClasses;

    [TestFixture]
    public class InteropIndexProcessorTests : ProcessorTests<InteropIndexProcessor>
    {
        public InteropIndexProcessorTests()
            : base("/app1/ifd/exif/interop/{ushort=1}")
        { }

        [TestCase("R03", "DCF option File (Adobe RGB)")]
        [TestCase("R98", "DCF basic File (sRGB)")]
        [TestCase("THM", "DCF Thumbnail File")]
        public void ValidValueWrittenToMetadata(string input, string expected)
        {
            var metadata = new Metadata();
            Processor.Process(metadata, input);

            var result = metadata.Interop;
            result.Should().Be(expected);
        }

        [Test]
        public void InvalidValueCreatesLogEntry()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, "Invalid");
            var processor = Processor as ISupportErrorableQueries;
            var log = processor?.Log as TestLog;
            Assert.IsNotNull(log);
            log.Messages.Count.Should().Be(1);
            log.Messages.First().Level.Should().Be("Warning");
            log.Messages.First().Message.Should().Be(string.Format(processor.Error, "Invalid"));
        }

        [Test]
        public void InvalidValueNotWrittenToMetadata()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, "Invalid");

            var result = metadata.Interop;
            result.Should().BeNull();
        }

        [Test]
        public void NullValueNotWrittenToMetadata()
        {
            var metadata = new Metadata();
            Processor.Process(metadata, null);

            var result = metadata.Interop;
            result.Should().BeNull();
        }
    }
}