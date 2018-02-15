namespace MetadataExtractor.Processors
{
    public class DescriptionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{uint=270}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.Description = ExifHelper.GetString(property);
            }
        }
    }
}