namespace MetadataExtractor
{
    public interface ISupportErrorableQueries : ISupportQueries
    {
        string Error { get; }
        ILog Log { get; set; }
    }
}