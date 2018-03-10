namespace MetadataExtractor.Processors
{
    public class CopyrightProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=33432}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.Copyright = ExifHelper.GetString(property);
            }
        }
    }
}