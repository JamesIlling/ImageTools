namespace MetadataExtractor.Tests.TestClasses
{
    class TestProcessor : ISupportQueries
    {
        public string Query => "/app1/Thumb/{}";
        public bool Called { get; private set; }

        public void Process(Metadata metadata, object property)
        {
            Called = true;
        }
    }
}
