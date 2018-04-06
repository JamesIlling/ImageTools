namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using System.Text;
    using System.Windows.Media.Imaging;
    using FluentAssertions;
    using NUnit.Framework;
    using TestBaseClasses;

    public abstract class SeparatedStringProcessorTests<T> : ProcessorTests<T> where T : ISupportQueries
    {
        private readonly Func<Metadata, string> _getMetadata;

        protected SeparatedStringProcessorTests(Func<Metadata, string> getMetadata, string query)
            : base(query)
        {
            _getMetadata = getMetadata;
        }

        [Test]
        public void NoValueStoredIfPropertyIsNotBitmapMetadataBlob()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, "");

            var result = _getMetadata(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);

            var result = _getMetadata(metadata);
            result.Should().BeNull();
        }

        [Test]
        public void ValidValueWrittenToMetadata()
        {
            var metadata = new Metadata();
            var input = new BitmapMetadataBlob(Encoding.ASCII.GetBytes("test"));

            Processor.Process(metadata, input);

            var result = _getMetadata(metadata);
            result.Should().Be("t.e.s.t");
        }
    }
}