namespace MetadataExtractor.Processors
{
    internal class ExifVersionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9000;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ExifVersion = ExifHelper.GetString(property);
        }
    }
}