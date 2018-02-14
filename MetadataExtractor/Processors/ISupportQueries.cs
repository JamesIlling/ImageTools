namespace MetadataExtractor.Processors
{
    public interface ISupportQueries
    {
        string Query { get; }
        void Process(Metadata metadata, object property);
    }
}