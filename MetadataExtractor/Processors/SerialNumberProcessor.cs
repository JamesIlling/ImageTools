namespace MetadataExtractor.Processors
{
    public class SerialNumberProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42033}";

        public void Process(Metadata metadata, object property)
        {
            if (string.IsNullOrEmpty(metadata.CameraSerialNumber))
            {
                metadata.CameraSerialNumber = ExifHelper.GetString(property);
            }
        }
    }
}