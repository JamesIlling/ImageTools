namespace MetadataExtractor.Tests
{
    using System.Collections.Generic;

    public class NoProcessors : IGetProcessors
    {
        public List<IMetaDataElementProcessor> GetAll()
        {
            return new List<IMetaDataElementProcessor>();
        }
    }
}