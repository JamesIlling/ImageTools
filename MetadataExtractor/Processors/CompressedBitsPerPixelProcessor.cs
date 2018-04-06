namespace MetadataExtractor.Processors
{
    public class CompressedBitsPerPixelProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37122}";
        public void Process(Metadata metadata, object property)
        {
            metadata.CompressedBitsPerPixel = ExifHelper.GetRational(property);
        }
    }
}
