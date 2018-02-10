namespace MetadataExtractor.Processors
{
    using Enums;

    internal class SensingMethodProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA217;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.SensingMethod = (SensingMethodEnum) ExifHelper.GetShort(property);
        }
    }
}