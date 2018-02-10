namespace MetadataExtractor.Processors
{
    using Enums;

    internal class ResolutionUnitProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x128;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ResolutionUnit = (ResolutionUnitEnum) ExifHelper.GetShort(property);
        }
    }
}