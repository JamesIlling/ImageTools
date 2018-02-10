namespace MetadataExtractor.Processors
{
    using Enums;

    internal class ThumbnailResolutionUnitProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x5030;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ThumbnailResolutionUnit = (ResolutionUnitEnum) ExifHelper.GetShort(property);
        }
    }
}