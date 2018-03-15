namespace MetadataExtractor.Tests
{
    using DependencyFactory;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;

    public abstract class ProcessorTests<T> where T : ISupportQueries
    {
        protected ProcessorTests(string query)
        {
            DependencyInjection.RegisterType<ILog, TestLog>();
            Processor = (ISupportQueries) DependencyInjection.Resolve(typeof(T));
            Query = query;
        }

        protected ISupportQueries Processor { get; }
        protected string Query { get; set; }

        [Test]
        public void QueryIsExpected()
        {
            Processor.Query.Should().Be(Query);
        }
    }
}