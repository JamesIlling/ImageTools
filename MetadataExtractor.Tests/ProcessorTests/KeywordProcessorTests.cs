namespace MetadataExtractor.Tests.ProcessorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class KeywordProcessorTests : ProcessorTests<KeywordProcessor>
    {
        public KeywordProcessorTests()
            : base("System.Keywords")
        {}

        [Test]
        public void NoValueStoredIfPropertyIfNotStringArray()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, "Test");

            metadata.Keywords.Should().BeNull();
        }


        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            metadata.Keywords.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var metadata = new Metadata();
            var input = new[] {"Test1", "Test2"};

            Processor.Process(metadata, input);

            metadata.Keywords.Should().Equal(input);
        }
    }
}