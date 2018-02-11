namespace MetadataExtractor.Processors
{
    public class RecommendedExposureIndexProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8832;
        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.RecommendedExposureIndex = ExifHelper.GetLong(property);
        }
    }
}
