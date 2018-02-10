namespace MetadataExtractor.Processors
{
    using Enums;

    internal class CustomRenderingProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA401;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.CustomRendering = (CustomRenderingEnum) ExifHelper.GetShort(property);
        }
    }
}