namespace MetadataExtractor.Processors
{
    internal class EditingSoftwareProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x0131;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.EditingSoftware = ExifHelper.GetString(property);
        }
    }
}