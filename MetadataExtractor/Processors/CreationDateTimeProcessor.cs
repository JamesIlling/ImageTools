namespace MetadataExtractor.Processors
{
    using System;
    using System.Globalization;

    public class CreationDateTimeProcessor : ISupportQueries
    {
        // called DateTimeDigitized by the EXIF spec.
        private const string DateTimeFormat = "yyyy:MM:dd HH:mm:ss";
        public string Query => "/app1/ifd/exif/subifd:{uint=36868}";

        public void Process(Metadata metadata, object property)
        {
            var captureTime = ExifHelper.GetString(property);
            if (DateTime.TryParseExact(captureTime, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal, out var value))
            {
                metadata.CreationTime = value;
            }
        }
    }
}