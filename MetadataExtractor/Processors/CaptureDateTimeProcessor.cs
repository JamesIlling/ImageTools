namespace MetadataExtractor.Processors
{
    using System;
    using System.Globalization;

    public class CaptureDateTimeProcessor : IMetaDataElementProcessor
    {
        //(date/time when original image was taken)
        private const string DateTimeFormat = "yyyy:MM:dd HH:mm:ss";
        public int Id => 0x9003;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var captureTime = ExifHelper.GetString(property);
            if (DateTime.TryParseExact(captureTime, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal, out var value))
            {
                metadata.CaptureTime = value;
            }
        }
    }
}