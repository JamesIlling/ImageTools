namespace MetadataExtractor.Processors
{
    public class XResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=282}";

        public void Process(Metadata metadata, object property)
        {
            metadata.XResolution = ExifHelper.GetRational(property);
        }
    }
}