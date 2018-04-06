namespace MetadataExtractor.Processors
{
    public class CameraSerialProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=50735}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null && string.IsNullOrEmpty(metadata.CameraSerialNumber))
            {
                metadata.CameraSerialNumber = ExifHelper.GetString(property);

            }
        }
    }
}