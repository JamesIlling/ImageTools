namespace MetadataExtractor.Tests.TestBaseClasses
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
            Processor = DependencyInjection.Resolve<T>();
            Query = query;
        }

        protected ISupportQueries Processor { get; }

        private string Query { get; }

        [Test]
        public void QueryIsExpected()
        {
            Processor.Query.Should().Be(Query);
        }
    }
}