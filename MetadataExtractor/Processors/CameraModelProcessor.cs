namespace MetadataExtractor.Processors
{
    public class CameraModelProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=272}";


        public void Process(Metadata metadata, object property)
        {
            metadata.CameraModel = ExifHelper.GetString(property);
        }
    }
}