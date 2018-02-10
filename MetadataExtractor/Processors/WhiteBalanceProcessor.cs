namespace MetadataExtractor.Processors
{
    using Enums;

    internal class WhiteBalanceProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA403;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.WhiteBalance = (WhiteBalanceEnum) ExifHelper.GetShort(property);
        }
    }
}