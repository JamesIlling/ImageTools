namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class YCbCrPositioningProcessor : IErrorableMetaDataElementProcessor
    {
        public string Error => "Unknown YCbCr Positioning value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0x213;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(YCbCrPositioningEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.YCbCrPositioning = (YCbCrPositioningEnum) propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}