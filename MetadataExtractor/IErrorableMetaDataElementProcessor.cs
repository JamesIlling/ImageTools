namespace MetadataExtractor
{
    public interface IErrorableMetaDataElementProcessor : IMetaDataElementProcessor
    {
        string Error { get; }
        ILog Log { get; set; }
    }
}