namespace MetadataExtractor.Processors
{
    using Enums;

    internal class MeteringModeProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9207;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.MeteringMode = (MeteringModeEnum) ExifHelper.GetShort(property);
        }
    }
}