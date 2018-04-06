namespace MetadataExtractor.Processors
{
    public class ThumbnailSizeProcessor : ISupportQueries
    {
        public string Query => "/app1/thumb/{ushort=514}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailSize = ExifHelper.GetLong(property);
        }
    }
}