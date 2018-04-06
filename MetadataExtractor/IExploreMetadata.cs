namespace MetadataExtractor
{
    using System.Collections.Generic;
    using System.IO;

    public interface IExploreMetadata
    {        
        IEnumerable<MetadataItem> Explore(Stream stream, bool mapToProcessors, bool onlyUnknown );
    }
}