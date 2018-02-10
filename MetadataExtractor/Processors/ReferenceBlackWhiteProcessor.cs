namespace MetadataExtractor.Processors
{
    public class ReferenceBlackWhiteProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x0214;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ReferenceBlackWhite = ExifHelper.GetRational(property);
        }
    }
}