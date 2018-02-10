namespace MetadataExtractor.Processors
{
    public class ChrominanceTableProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x5091;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ChrominanceTable = property.Value;
        }
    }
}