namespace MetadataExtractor.Processors.Xmp
{
    public class LensSerialNumberProcessor : ISupportQueries
    {
        public string Query => "/xmp/aux:LensID";
        public void Process(Metadata metadata, object property)
        {
            metadata.LensSerialNumber = ExifHelper.GetString(property);
        }
    }
}
