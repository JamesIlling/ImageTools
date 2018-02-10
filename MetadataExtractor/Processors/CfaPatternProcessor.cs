namespace MetadataExtractor.Processors
{
    internal class CfaPatternProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA302;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.CfaPattern = property.Value;
        }
    }
}