namespace MetadataExtractor.Processors
{
    public class ModifiedDateTimeSubsecondProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37520}";
        public void Process(Metadata metadata, object property)
        {
            if (metadata.ModifiedTime != null)
            {
                if (property != null)
                {
                    var ms = double.Parse(ExifHelper.GetString(property));
                    metadata.ModifiedTime =
                        metadata.ModifiedTime.Value.AddMilliseconds(ms);
                }
            }
        }
    }
}