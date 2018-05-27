namespace MetadataExtractor.Processors.Xmp
{
    public class EditingSoftwareProcessor : ISupportQueries
    {
        public string Query => "/xmp/xmp:CreatorTool";

        public void Process(Metadata metadata, object property)
        {
            metadata.EditingSoftware = ExifHelper.GetString(property);
        }
    }
}