namespace MetadataExtractor.Processors.Exif
{
    public class FNumberProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=33437}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FNumber = ExifHelper.GetRational(property);
        }
    }
}