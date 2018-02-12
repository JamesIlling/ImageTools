﻿namespace MetadataExtractor.Processors
{
    using System;
    using System.Globalization;

    internal class ModifiedDateTimeProcessor : IMetaDataElementProcessor

    {
        private const string DateTimeFormat = "yyyy:MM:dd hh:mm:ss";
        public int Id => 0x0132;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var captureTime = ExifHelper.GetString(property);
            if (DateTime.TryParseExact(captureTime, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal, out var value))
            {
                metadata.ModifiedTime = value;
            }
        }
    }
}