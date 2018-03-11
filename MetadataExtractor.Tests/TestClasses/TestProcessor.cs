namespace MetadataExtractor.Tests.TestClasses
{
    internal class TestProcessor : ISupportQueries
    {
        public bool Called { get; private set; }
        public string Query => "/app1/Thumb/{}";

        public void Process(Metadata metadata, object property)
        {
            Called = true;
        }
    }
}