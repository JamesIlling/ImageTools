namespace MetadataExtractor.Processors
{
    public class ExposureTimeProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x829A;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ExposureTime = ExifHelper.GetSignedRational(property);
        }
    }
}