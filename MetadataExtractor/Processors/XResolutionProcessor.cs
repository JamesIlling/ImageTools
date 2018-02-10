namespace MetadataExtractor.Processors
{
    internal class XResolutionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x011A;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.XResolution = ExifHelper.GetRational(property);
        }
    }
}