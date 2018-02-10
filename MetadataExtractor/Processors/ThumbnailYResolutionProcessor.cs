namespace MetadataExtractor.Processors
{
    internal class ThumbnailYResolutionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x502E;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ThumbnailYResolution = ExifHelper.GetRational(property);
        }
    }
}