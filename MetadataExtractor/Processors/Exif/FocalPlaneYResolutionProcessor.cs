namespace MetadataExtractor.Processors.Exif
{
    public class FocalPlaneYResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41487}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalPlaneYResolution = ExifHelper.GetRational(property);
        }
    }
}