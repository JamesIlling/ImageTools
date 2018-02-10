namespace MetadataExtractor.Processors
{
    using Enums;

    internal class ColourSpaceProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA001;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ColourSpace = (ColourSpaceEnum) ExifHelper.GetShort(property);
        }
    }
}