namespace MetadataExtractor.Processors
{
    internal class LensManufacturerProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA433;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.LensManufacturer = ExifHelper.GetString(property);
        }
    }
}