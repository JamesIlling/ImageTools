namespace MetadataExtractor.Processors
{
    public class ThumbnailXResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/thumb/{ushort=282}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailXResolution = ExifHelper.GetRational(property);
        }
    }
}