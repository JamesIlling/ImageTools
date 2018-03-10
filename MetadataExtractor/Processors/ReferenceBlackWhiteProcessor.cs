namespace MetadataExtractor.Processors
{
    public class ReferenceBlackWhiteProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{uint=532}";
        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ReferenceBlackWhite = ExifHelper.GetRational(property);
            }
        }
    }
}