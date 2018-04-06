namespace MetadataExtractor.Tests
{
    public interface IDisplay
    {
        bool Supported(object value);
        string GetText(object value);
    }
}