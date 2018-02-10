namespace MetadataExtractor.Processors
{
    internal class LensSerialProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA435;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.LensSerialNumber = ExifHelper.GetString(property);
        }
    }
}