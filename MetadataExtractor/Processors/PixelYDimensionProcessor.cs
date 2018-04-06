namespace MetadataExtractor.Processors
{
    public class PixelYDimensionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=40963}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Height = ExifHelper.GetShort(property);
        }
    }
}