namespace MetadataExtractor.Processors
{
    public class ShutterSpeedApexProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=37377}";
        public void Process(Metadata metadata, object property)
        {
            metadata.ShutterSpeedApexValue = ExifHelper.GetSignedRational(property);
        }
    }
}