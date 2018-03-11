namespace MetadataExtractor
{
    public class MetadataItem
    {
        public MetadataItem(string type, string query)
        {
            Type = type;
            Query = query;
        }

        public string Type { get; set; }

        public string Query { get; set; }
    }
}