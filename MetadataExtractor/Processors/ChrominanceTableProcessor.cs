namespace MetadataExtractor.Processors
{
    public class ChrominanceTableProcessor : ISupportQueries
    {
        public string Query => "/chrominance/TableEntry";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ChrominanceTable = property as ushort[];
            }
        }
    }
}