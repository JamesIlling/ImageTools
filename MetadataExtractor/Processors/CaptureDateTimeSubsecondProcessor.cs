namespace MetadataExtractor.Processors
{
    public class CaptureDateTimeSubsecondProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37521}";

        public void Process(Metadata metadata, object property)
        {
            if (metadata.CaptureTime != null)
            {
                var ms = double.Parse(ExifHelper.GetString(property));
                metadata.CaptureTime = metadata.CaptureTime.Value.AddMilliseconds(ms);
            }
        }
    }
}