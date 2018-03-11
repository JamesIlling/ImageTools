namespace MetadataExtractor.Processors
{
    public class ThumbnailYResolutionProcessor : ISupportQueries
    {

        public string Query => "/app1/thumb/{ushort=283}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailYResolution = ExifHelper.GetRational(property);
        }
    }
}