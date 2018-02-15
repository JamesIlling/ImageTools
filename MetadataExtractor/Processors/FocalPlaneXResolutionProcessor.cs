namespace MetadataExtractor.Processors
{
    public class FocalPlaneXResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=41486}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalPlaneXResolution = ExifHelper.GetRational(property);
        }
    }
}