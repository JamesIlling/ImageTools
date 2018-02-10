namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ColourSpaceProcessor : IMetaDataElementProcessor
    {
        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0xA001;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(ColourSpaceEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.ColourSpace = (ColourSpaceEnum) propertyValue;
            }
            else
            {
                Log?.Info("ColourSpace Value:0x" + propertyValue.ToString("X4"));
            }
        }
    }
}