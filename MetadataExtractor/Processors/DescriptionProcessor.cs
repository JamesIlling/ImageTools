namespace MetadataExtractor.Processors
{
    public class DescriptionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=270}";


        public void Process(Metadata metadata, object property)
        {
            metadata.Description = ExifHelper.GetString(property);
        }
    }
}