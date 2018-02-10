namespace MetadataExtractor.Processors
{
    using Enums;

    internal class SubjectDistanceProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA40C;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.SubjectDistance = (SubjectDistanceEnum) ExifHelper.GetShort(property);
        }
    }
}