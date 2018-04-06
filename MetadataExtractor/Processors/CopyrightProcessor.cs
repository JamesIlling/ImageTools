namespace MetadataExtractor.Processors
{
    public class CopyrightProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=33432}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Copyright = ExifHelper.GetString(property);
        }
    }
}