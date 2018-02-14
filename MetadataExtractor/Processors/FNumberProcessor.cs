namespace MetadataExtractor.Processors
{
    public class FNumberProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{ushort=33437}";
        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.FNumber = ExifHelper.GetRational(property);
            }
        }
    }
}