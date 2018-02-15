namespace MetadataExtractor.Processors
{
    public class FocalLength35MmEquivalentProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=41989}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalLengthIn35MmFormat = ExifHelper.GetShort(property);
        }
    }
}