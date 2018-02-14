namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class GainControlProcessor : IErrorableMetaDataElementProcessor
    {
        public string Error => "Unknown Gain Control value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0xA407;

        public void Process(Metadata metadata, ExifProperty property)
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