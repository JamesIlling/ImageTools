namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ExposureProgramProcessor : ISupportErrorableQueries
    {
        public string Error => "Unknown Exposure program value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/subifd:{uint=34850}";

        public void Process(Metadata metadata, object property)
        {
            var enumValues = Enum.GetValues(typeof(ExposureProgramEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.ExposureProgram = (ExposureProgramEnum)propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}