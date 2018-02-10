namespace MetadataExtractor.Processors
{
    using Enums;

    internal class SensitivityTypeProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8830;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.SensitivityType = (SensitivityTypeEnum) ExifHelper.GetShort(property);
        }
    }
}