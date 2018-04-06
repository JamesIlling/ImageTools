namespace MetadataExtractor.Tests.TestClasses
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal class TestProcessorLocator : IGetProcessors
    {
        private readonly ISupportQueries _item;

        public TestProcessorLocator()
        {}

        public TestProcessorLocator(ISupportQueries item)
        {
            _item = item;
        }

        public bool Called { get; private set; }

        public IEnumerable<T> GetAll<T>()
        {
            Called = true;
            if (typeof(T) == typeof(ISupportQueries) && _item != null)
            {
                return new List<T> {(T) _item};
            }
            return new List<T>();
        }
    }
}