namespace MetadataExtractor.Processors
{
    internal class ShutterSpeedApexProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9201;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ShutterSpeedApexValue = ExifHelper.GetRational(property);
        }
    }
}