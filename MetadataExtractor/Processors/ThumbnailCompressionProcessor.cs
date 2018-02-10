namespace MetadataExtractor.Processors
{
    using Enums;

    internal class ThumbnailCompressionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x5023;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ThumbnailCompression = (CompressionEnum) ExifHelper.GetShort(property);
        }
    }
}