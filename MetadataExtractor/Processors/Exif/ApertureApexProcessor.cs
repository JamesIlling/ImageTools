namespace MetadataExtractor.Processors.Exif
{
    public class ApertureApexProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37378}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ApertureApexValue = ExifHelper.GetRational(property);
        }
    }
}