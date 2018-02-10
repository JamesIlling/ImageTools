namespace MetadataExtractor.Processors
{
    internal class ThumbnailXResolutionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x502D;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ThumbnailXResolution = ExifHelper.GetRational(property);
        }
    }
}