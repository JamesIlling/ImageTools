namespace MetadataExtractor.Processors
{
    public class CreationDateTimeSubsecondProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=37522}";

        public void Process(Metadata metadata, object property)
        {
            if (metadata.CreationTime != null)
            {
                var ms = double.Parse(ExifHelper.GetString(property));
                metadata.CreationTime = metadata.CreationTime.Value.AddMilliseconds(ms);
            }
        }
    }
}