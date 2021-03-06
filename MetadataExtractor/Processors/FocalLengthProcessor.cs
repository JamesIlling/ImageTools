﻿namespace MetadataExtractor.Processors
{
    public class FocalLengthProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37386}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalLength = ExifHelper.GetRational(property);
        }
    }
}