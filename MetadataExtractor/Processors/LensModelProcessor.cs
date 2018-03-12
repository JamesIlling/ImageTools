namespace MetadataExtractor.Processors
{
    public class LensModelProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42036}";


        public void Process(Metadata metadata, object property)
        {
            metadata.Lens = ExifHelper.GetString(property);
        }
    }
}