namespace MetadataExtractor.Processors
{
    using Enums;

    internal class SharpnessProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA40A;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Sharpness = (SharpnessEnum) ExifHelper.GetShort(property);
        }
    }
}