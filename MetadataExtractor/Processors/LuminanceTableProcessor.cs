namespace MetadataExtractor.Processors
{
    internal class LuminanceTableProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x5090;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.LuminanceTable = property.Value;
        }
    }
}