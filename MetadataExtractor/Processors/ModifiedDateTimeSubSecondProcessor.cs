namespace MetadataExtractor.Processors
{
    public class ModifiedDateTimeSubsecondProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37520}";

        public void Process(Metadata metadata, object property)
        {
            if (metadata.ModifiedTime != null)
            {
                {
                    var value = ExifHelper.GetString(property);
                    if (value != null)
                    {
                        var ms = double.TryParse(value, out var milliseconds);
                        if (ms && milliseconds >= 0)
                        {
                            metadata.ModifiedTime =
                                metadata.ModifiedTime.Value.AddMilliseconds(milliseconds);
                        }
                    }
                }
            }
        }
    }
}