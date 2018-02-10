namespace MetadataExtractor.Processors
{
    internal class ThumbnailProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x501B;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Thumbnail = property.Value;
        }
    }
}