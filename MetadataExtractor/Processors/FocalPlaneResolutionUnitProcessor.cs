namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class FocalPlaneResolutionUnitProcessor : IErrorableMetaDataElementProcessor
    {
        public string Error => "Unknown Focal Plane Unit value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0xA210;

        public void Process(Metadata metadata, ExifProperty property)
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