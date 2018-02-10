namespace MetadataExtractor.Processors
{
    using Enums;

    internal class FocalPlaneResolutionUnit : IMetaDataElementProcessor
    {
        public int Id => 0xA210;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.FocalPlaneResolutionUnit = (ResolutionUnitEnum) ExifHelper.GetShort(property);
        }
    }
}