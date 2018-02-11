﻿namespace MetadataExtractor.Processors
{
    using Enums;

    public class ExposureModeProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA402;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.ExposureMode = (ExposureModeEnum) ExifHelper.GetShort(property);
        }
    }
}