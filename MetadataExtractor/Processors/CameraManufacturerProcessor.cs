namespace MetadataExtractor.Processors
{
    public class CameraManufacturerProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x010F;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.CameraManufacturer = ExifHelper.GetString(property);
        }
    }
}