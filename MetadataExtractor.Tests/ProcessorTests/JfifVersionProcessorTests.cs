namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifVersionProcessorTests : ProcessorTests<JfifVersionProcessor>
    {
        public JfifVersionProcessorTests()
            : base("/app0/{ushort=0}")
        { }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = metadata.JfifVersion;
            result.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var metadata = new Metadata();
            const ushort input = 0x0102;

            Processor.Process(metadata, input);

            var result = metadata.JfifVersion;
            result.Should().Be("2.1");
        }
    }
}