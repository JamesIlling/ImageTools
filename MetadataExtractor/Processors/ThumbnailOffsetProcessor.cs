namespace MetadataExtractor.Processors
{
    internal class ThumbnailOffsetProcessor : ISupportQueries
    {
        public string Query => "/app1/thumb/{ushort=513}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailOffset = ExifHelper.GetLong(property);
        }
    }
}