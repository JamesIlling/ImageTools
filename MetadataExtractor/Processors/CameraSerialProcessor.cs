namespace MetadataExtractor.Processors
{
    public class CameraSerialProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xC62F;

        public void Process(Metadata metadata, ExifProperty property)
        {
            if (string.IsNullOrEmpty(metadata.CameraSerialNumber))
            {
                metadata.CameraSerialNumber = ExifHelper.GetString(property);
            }
        }
    }
}