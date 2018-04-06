namespace MetadataExtractor.Tests.TestBaseClasses
{
    using NUnit.Framework;

    public abstract class UnsupportedProcessorTests<T> : ProcessorTests<T> where T : ISupportQueries
    {
        protected UnsupportedProcessorTests(string query)
            : base(query)
        { }

        [Test]
        public void EnsureProcessorDoesNotThrow()
        {
            Assert.DoesNotThrow(() => Processor.Process(new Metadata(), null));
        }
    }
}