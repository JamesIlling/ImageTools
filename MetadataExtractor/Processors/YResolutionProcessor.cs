namespace MetadataExtractor.Processors
{
    internal class YResolutionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x11B;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.YResolution = ExifHelper.GetRational(property);
        }
    }
}