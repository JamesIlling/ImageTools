namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class YCbCrPositioningProcessor : IMetaDataElementProcessor
    {
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
                Log?.Info("YCbCrPositioningEnum Value:0x" + propertyValue.ToString("X4"));
            }
        }
    }
}