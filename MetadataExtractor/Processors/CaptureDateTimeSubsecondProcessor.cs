namespace MetadataExtractor.Processors
{
    public class CaptureDateTimeSubsecondProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37521}";

        public void Process(Metadata metadata, object property)
        {
            if (metadata.CaptureTime != null)
            {
                var value = ExifHelper.GetString(property);
                if (value != null)
                {
                    var ms = double.TryParse(value, out var milliseconds);
                    if (ms && milliseconds >= 0)
                    {
                        metadata.CaptureTime = metadata.CaptureTime.Value.AddMilliseconds(milliseconds);
                    }
                }
            }
        }
    }
}