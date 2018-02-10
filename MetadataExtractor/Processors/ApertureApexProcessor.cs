namespace MetadataExtractor.Processors
{
    public class ApertureApexProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9202;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ApertureApexValue = ExifHelper.GetRational(property);
        }
    }
}