namespace MetadataExtractor.Processors.Exif
{
    public class ShutterSpeedApexProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37377}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ShutterSpeedApexValue = ExifHelper.GetSignedRational(property);
        }
    }
}