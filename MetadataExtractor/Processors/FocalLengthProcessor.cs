namespace MetadataExtractor.Processors
{
    internal class FocalLengthProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x920A;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.FocalLength = ExifHelper.GetRational(property);
        }
    }
}