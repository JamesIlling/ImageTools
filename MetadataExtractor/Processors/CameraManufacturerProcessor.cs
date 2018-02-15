﻿namespace MetadataExtractor.Processors
{
    public class CameraManufacturerProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{uint=271}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.CameraManufacturer = ExifHelper.GetString(property);
            }
        }
    }
}