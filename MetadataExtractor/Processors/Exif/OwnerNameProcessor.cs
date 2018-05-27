namespace MetadataExtractor.Processors.Exif
{
    public class OwnerNameProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42032}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Owner = ExifHelper.GetString(property);
        }
    }
}