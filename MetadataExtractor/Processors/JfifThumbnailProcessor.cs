namespace MetadataExtractor.Processors
{
    public class JfifThumbnailProcessor : UnsuportedQuery
    {
        public JfifThumbnailProcessor()
            : base("/app0/{ushort=6}")
        { }
    }
}