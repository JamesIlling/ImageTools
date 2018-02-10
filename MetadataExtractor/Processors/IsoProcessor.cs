namespace MetadataExtractor.Processors
{
    internal class IsoProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8827;

        public void Process(Metadata metadata, ExifProperty property)
        {
            Metadata.Iso = ExifHelper.GetShort(property);
        }
    }
}