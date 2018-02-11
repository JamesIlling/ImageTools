namespace MetadataExtractor.Processors
{
    public class FocalLength35MmEquivalentProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xa405;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.FocalLengthIn35MmFormat = ExifHelper.GetShort(property);
        }
    }
}