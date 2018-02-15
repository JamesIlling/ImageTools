namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class FocalPlaneResolutionUnitProcessor : ISupportErrorableQueries
    {
        public string Error => "Unknown Focal Plane Unit value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/subifd:{uint=41488}";

        public void Process(Metadata metadata, object property)
        {
            var enumValues = Enum.GetValues(typeof(ResolutionUnitEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.FocalPlaneResolutionUnit = (ResolutionUnitEnum) propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}