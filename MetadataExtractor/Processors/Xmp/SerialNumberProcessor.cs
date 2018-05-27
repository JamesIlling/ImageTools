namespace MetadataExtractor.Processors.Xmp
{
    public class SerialNumberProcessor : ISupportQueries
    {
        public string Query => "/xmp/aux:SerialNumber";
        public void Process(Metadata metadata, object property)
        {
            metadata.CameraSerialNumber = ExifHelper.GetString(property);
        }
    }
}
