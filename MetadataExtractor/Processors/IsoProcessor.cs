namespace MetadataExtractor.Processors
{
    public class IsoProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8827;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Iso = ExifHelper.GetShort(property);
        }
    }
}