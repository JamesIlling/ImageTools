namespace MetadataExtractor.Processors
{
    using Enums;

    internal class SceneCaptureTypeProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA406;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.SceneCaptureType = (SceneCaptureTypeEnum) ExifHelper.GetShort(property);
        }
    }
}