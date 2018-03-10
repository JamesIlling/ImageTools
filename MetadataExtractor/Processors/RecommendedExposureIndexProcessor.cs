namespace MetadataExtractor.Processors
{
    public class RecommendedExposureIndexProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=34866}";
        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.RecommendedExposureIndex = ExifHelper.GetLong(property);
            }
        }
    }
}
