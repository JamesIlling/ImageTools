﻿namespace MetadataExtractor.Processors
{
    public class ApertureApexProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=37378}";

        public  void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ApertureApexValue = ExifHelper.GetRational(property);
            }
        }
    }
}