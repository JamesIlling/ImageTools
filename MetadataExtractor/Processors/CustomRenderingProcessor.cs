namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class CustomRenderingProcessor : ISupportErrorableQueries
    {
        public string Error => "Unknown Custom Rendering value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/subifd:{uint=41985}";

        public void Process(Metadata metadata, object property)
        {
            var enumValues = Enum.GetValues(typeof(CustomRenderingEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.CustomRendering = (CustomRenderingEnum) propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}