namespace MetadataExtractor.Processors
{
    public class YResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=283}";

        public void Process(Metadata metadata, object property)
        {
            metadata.YResolution = ExifHelper.GetRational(property);
        }
    }
}