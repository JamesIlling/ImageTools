namespace MetadataExtractor.Processors
{
    public class ExposureCompensationProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=37380}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ExposureCompensation = ExifHelper.GetSignedRational(property);
        }
    }
}