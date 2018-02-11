namespace MetadataExtractor.Processors
{
    public class ExposureCompensationProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9204;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ExposureCompensation = ExifHelper.GetSignedRational(property);
        }
    }
}