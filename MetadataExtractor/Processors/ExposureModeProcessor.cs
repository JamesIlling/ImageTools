namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ExposureModeProcessor : ISupportErrorableQueries
    {
        public string Error => "Unknown Exposure mode value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/subifd:{uint=41986}";

        public void Process(Metadata metadata, object property)
        {
            var enumValues = Enum.GetValues(typeof(ExposureModeEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.ExposureMode = (ExposureModeEnum) propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}