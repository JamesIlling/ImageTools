namespace MetadataExtractor
{
    public interface IMetaDataElementProcessor
    {
        int Id { get; }
        void Process(Metadata metadata, ExifProperty property);
    }
}