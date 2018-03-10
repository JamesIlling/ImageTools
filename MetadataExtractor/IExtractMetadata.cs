namespace MetadataExtractor
{
    using System.IO;

    public interface IExtractMetadata
    {
        Metadata ExtractMetadata(Stream image);
    }
}