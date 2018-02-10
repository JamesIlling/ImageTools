namespace MetadataExtractor.Processors
{
    internal class CameraSerialProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA431;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.CameraSerialNumber = ExifHelper.GetString(property);
        }
    }
}