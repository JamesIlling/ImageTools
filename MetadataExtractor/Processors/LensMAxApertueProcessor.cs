namespace MetadataExtractor.Processors
{
    public class LensMaxApertueProcessor : ISupportQueries
    {
        public string Query=> "/app1/ifd/exif/subifd:{uint=37381}";

        public void Process(Metadata metadata, object property)
        {
            metadata.LensMaxAperture = ExifHelper.GetRational(property);
        }
    }
}