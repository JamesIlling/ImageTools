namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class GainControlProcessor : ISupportErrorableQueries
    {
        public string Error => "Unknown Gain Control value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/subifd:{uint=41991}";

        public void Process(Metadata metadata, object property)
        {
            var enumValues = Enum.GetValues(typeof(GainControlEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.GainControl = (GainControlEnum) propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}