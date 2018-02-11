namespace MetadataExtractor.Processors
{
    public class FNumberProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x829D;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.FNumber = ExifHelper.GetRational(property);
        }
    }
}