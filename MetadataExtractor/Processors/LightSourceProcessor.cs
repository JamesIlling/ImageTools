namespace MetadataExtractor.Processors
{
    using Enums;

    internal class LightSourceProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9208;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Lightsource = (LightSourceEnum) ExifHelper.GetShort(property);
        }
    }
}