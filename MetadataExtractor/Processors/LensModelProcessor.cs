namespace MetadataExtractor.Processors
{
    internal class LensModelProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA434;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Lens = ExifHelper.GetString(property);
        }
    }
}