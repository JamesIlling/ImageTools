namespace MetadataExtractor.Processors.Exif
{
    public class FocalPlaneXResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41486}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalPlaneXResolution = ExifHelper.GetRational(property);
        }
    }
}