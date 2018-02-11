namespace MetadataExtractor.Processors
{
    using Enums;

    public class ExposureProgramProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8822;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ExposureProgram = (ExposureProgramEnum) ExifHelper.GetShort(property);
        }
    }
}