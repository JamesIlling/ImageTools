namespace MetadataExtractor.Processors
{
    public class CreationDateTimeSubsecondProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37522}";

        public void Process(Metadata metadata, object property)
        {
            if (metadata.CreationTime != null)
            {
                var value = ExifHelper.GetString(property);
                if (value != null)
                {
                    var ms = double.TryParse(value, out var milliseconds);
                    if (ms && milliseconds >= 0)
                    {
                        metadata.CreationTime = metadata.CreationTime.Value.AddMilliseconds(milliseconds);
                    }
                }
            }
        }
    }
}