namespace MetadataExtractor
{
    using System.Collections.Generic;
    using System.IO;

    public interface IExploreMetadata
    {
        IEnumerable<MetadataItem> GetUnknownElements(Stream file);
    }
}