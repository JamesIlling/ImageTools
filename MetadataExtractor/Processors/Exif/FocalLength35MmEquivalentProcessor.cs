namespace MetadataExtractor.Processors.Exif
{
    public class FocalLength35MmEquivalentProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41989}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalLengthIn35MmFormat = ExifHelper.GetShort(property);
        }
    }
}