namespace MetadataExtractor.Processors
{
    public abstract class UnsuportedQuery : ISupportQueries
    {
        protected UnsuportedQuery(string query)
        {
            Query = query;
        }

        public string Query { get; }

        public void Process(Metadata metadata, object property)
        {
            // No action for unsupported queries.
        }
    }
}