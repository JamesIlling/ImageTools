namespace MetadataExtractor.Processors
{
    public class PixelXDimensionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=40962}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Width = ExifHelper.GetShort(property);
        }
    }
}