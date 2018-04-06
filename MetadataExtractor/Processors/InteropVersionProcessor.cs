namespace MetadataExtractor.Processors
{
    public class InteropVersionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/interop/{ushort=2}";

        public void Process(Metadata metadata, object property)
        {
            metadata.InteropVersion = ExifHelper.GetStringFromBlob(property);
        }
    }
}