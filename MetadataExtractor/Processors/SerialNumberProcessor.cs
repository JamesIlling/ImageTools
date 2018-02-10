namespace MetadataExtractor.Processors
{
    public class SerialNumberProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA431;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.CameraSerialNumber = ExifHelper.GetString(property);
        }
    }
}