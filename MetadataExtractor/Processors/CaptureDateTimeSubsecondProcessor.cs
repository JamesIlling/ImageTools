namespace MetadataExtractor.Processors
{
    public class CaptureDateTimeSubsecondProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9291;

        public void Process(Metadata metadata, ExifProperty property)
        {
            if (metadata.CaptureTime != null)
            {
                var ms = double.Parse(ExifHelper.GetString(property));
                metadata.CaptureTime = metadata.CaptureTime.Value.AddMilliseconds(ms);
            }
        }
    }
}