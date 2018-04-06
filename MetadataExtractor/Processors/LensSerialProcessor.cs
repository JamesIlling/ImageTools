namespace MetadataExtractor.Processors
{
    public class LensSerialProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42037}";

        public void Process(Metadata metadata, object property)
        {
            metadata.LensSerialNumber = ExifHelper.GetString(property);
        }
    }
}