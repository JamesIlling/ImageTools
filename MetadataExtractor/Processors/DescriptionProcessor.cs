namespace MetadataExtractor.Processors
{
    internal class DescriptionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x010E;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Description = ExifHelper.GetString(property);
        }
    }
}