namespace MetadataExtractor.Processors
{
    public class EditingSoftwareProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=305}";

        public void Process(Metadata metadata, object property)
        {
            metadata.EditingSoftware = ExifHelper.GetString(property);
        }
    }
}