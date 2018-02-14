namespace MetadataExtractor.Processors
{
    public class IccProfileProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8773;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.IccProfile = property.Value;
        }
    }
}