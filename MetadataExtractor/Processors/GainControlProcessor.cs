namespace MetadataExtractor.Processors
{
    using Enums;

    internal class GainControlProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA407;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.GainControl = (GainControlEnum) ExifHelper.GetShort(property);
        }
    }
}