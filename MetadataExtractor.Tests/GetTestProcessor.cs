namespace MetadataExtractor.Tests
{
    using System.Collections.Generic;

    public class GetTestProcessor : IGetProcessors
    {
        public static readonly TestProcessor Processor = new TestProcessor();

        public List<IMetaDataElementProcessor> GetAll()
        {
            return new List<IMetaDataElementProcessor> {Processor};
        }
    }
}