namespace MetadataExtractor.Processors
{
    public class LensSerialProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42037}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.LensSerialNumber = ExifHelper.GetString(property);
            }
        }
    }
}