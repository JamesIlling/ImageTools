namespace MetadataExtractor.Processors
{
    internal class CaptureDateTimeSubsecondProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9291;

        public void Process(Metadata metadata, ExifProperty property)
        {
            if (metadata.CaptureTime != null)
            {
                metadata.CaptureTime =
                    metadata.CaptureTime.Value.AddMilliseconds(double.Parse(ExifHelper.GetString(property)));
            }
        }
    }
}