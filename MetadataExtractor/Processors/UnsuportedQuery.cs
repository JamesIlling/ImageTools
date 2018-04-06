namespace MetadataExtractor.Processors
{
    public abstract class UnsuportedQuery : ISupportQueries
    {
        public UnsuportedQuery(string query)
        {
            Query = query;
        }

        public string Query { get; }

        public void Process(Metadata metadata, object property)
        {}
    }
}