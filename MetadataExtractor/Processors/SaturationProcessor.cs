namespace MetadataExtractor.Processors
{
    using Enums;

    internal class SaturationProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA409;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Saturation = (SaturationEnum) ExifHelper.GetShort(property);
        }
    }
}