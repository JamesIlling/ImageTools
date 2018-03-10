namespace MetadataExtractor.Tests.TestClasses
{
    using System.Collections.Generic;

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

        public List<T> GetAll<T>()
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