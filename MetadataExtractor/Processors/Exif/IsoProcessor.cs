namespace MetadataExtractor.Processors.Exif
{
    public class IsoProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=34855}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Iso = ExifHelper.GetShort(property);
        }
    }
}