namespace MetadataExtractor.Processors.Jfif
{
    public class JfifThumbnailProcessor : UnsuportedQuery
    {
        public JfifThumbnailProcessor()
            : base("/app0/{ushort=6}")
        { }
    }
}