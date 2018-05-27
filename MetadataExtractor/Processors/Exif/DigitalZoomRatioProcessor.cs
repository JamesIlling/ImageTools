namespace MetadataExtractor.Processors.Exif
{
    public class DigitalZoomRatioProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41988}";

        public void Process(Metadata metadata, object property)
        {
            metadata.DigitalZoomRatio = ExifHelper.GetRational(property);
        }
    }
}