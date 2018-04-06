namespace MetadataExtractor.Processors
{
    public class LuminanceTableProcessor : ISupportQueries
    {
        public string Query => "/luminance/TableEntry";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.LuminanceTable = property as ushort[];
            }
        }
    }
}