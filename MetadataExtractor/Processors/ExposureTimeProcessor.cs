namespace MetadataExtractor.Processors
{
    public class ExposureTimeProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=33434}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ExposureTime = ExifHelper.GetRational(property);
            }
        }
    }
}