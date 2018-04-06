namespace MetadataExtractor.Processors
{
    public class ThumbnailProcessor : UnsuportedQuery
    {
        public ThumbnailProcessor()
            : base("/app1/thumb/{}")
        {}
    }
}