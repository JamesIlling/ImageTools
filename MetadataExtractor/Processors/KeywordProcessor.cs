namespace MetadataExtractor.Processors
{
    public class KeywordProcessor : ISupportQueries
    {
        public string Query => "System.Keywords";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.Keywords = (string[]) property;
            }
        }
    }
}