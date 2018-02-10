namespace MetadataExtractor.Processors
{
    using System;
    using System.Globalization;

    public class CreationDateTimeProcessor : IMetaDataElementProcessor
    {
        // called DateTimeDigitized by the EXIF spec.
        private const string DateTimeFormat = "yyyy:MM:dd HH:mm:ss";
        public int Id => 0x9004;

        public void Process(Metadata metadata, ExifProperty property)
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