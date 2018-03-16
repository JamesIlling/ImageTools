namespace MetadataExtractor.Tests
{
    using DependencyFactory;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using TestClasses;

    public abstract class ErrorableProcessorTests<TProcessor> where TProcessor : ISupportErrorableQueries
    {
        protected ErrorableProcessorTests(string query)
        {
            DependencyInjection.RegisterType<ILog, TestLog>();
            Processor = (ISupportErrorableQueries) DependencyInjection.Resolve(typeof(TProcessor));
            Query = query;
        }

        protected ISupportErrorableQueries Processor { get; }

        private string Query { get; }

        [Test]
        public void QueryIsExpected()
        {
            Processor.Query.Should().Be(Query);
        }

        [Test]
        public void ErrorMessageContainsTypeName()
        {
            var name = NameUtils.GetNameFromProcessor(Processor);
            var error = $"Unknown {name} value:{{0:X4}}";
            Processor.Error.Should().Be(error);
        }
    }
}
