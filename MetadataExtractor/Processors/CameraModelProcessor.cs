namespace MetadataExtractor.Processors
{
    public class CameraModelProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{uint=272}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.CameraModel = ExifHelper.GetString(property);
            }
        }
    }
}