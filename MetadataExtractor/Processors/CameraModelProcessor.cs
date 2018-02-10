namespace MetadataExtractor.Processors
{
    internal class CameraModelProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x110;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.CameraModel = ExifHelper.GetString(property);
        }
    }
}