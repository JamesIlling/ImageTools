namespace MetadataExtractor
{
    using System.Collections.Generic;

    public interface IGetProcessors
    {
        IEnumerable<T> GetAll<T>();
    }
}