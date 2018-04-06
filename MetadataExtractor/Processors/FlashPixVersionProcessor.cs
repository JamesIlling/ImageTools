namespace MetadataExtractor.Processors
{
    public class FlashPixVersionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=40960}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FlashpixVersion = ExifHelper.GetStringFromBlob(property);
        }
    }
}