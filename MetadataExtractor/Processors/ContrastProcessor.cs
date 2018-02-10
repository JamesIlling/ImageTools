namespace MetadataExtractor.Processors
{
    using Enums;

    internal class ContrastProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA408;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Contrast = (ContrastEnum) ExifHelper.GetShort(property);
        }
    }
}