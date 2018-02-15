namespace MetadataExtractor.Processors
{
    public class DigitalZoomRatioProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=41988}";

        public  void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.DigitalZoomRatio = ExifHelper.GetRational(property);
            }
        }
    }
}