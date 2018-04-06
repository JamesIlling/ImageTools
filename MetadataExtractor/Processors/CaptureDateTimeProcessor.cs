namespace MetadataExtractor.Processors
{
    using System;
    using System.Globalization;

    public class CaptureDateTimeProcessor : ISupportQueries
    {
        //(date/time when original image was taken)
        private const string DateTimeFormat = "yyyy:MM:dd HH:mm:ss";

        public string Query => "/app1/ifd/exif/{ushort=36867}";


        public void Process(Metadata metadata, object property)
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