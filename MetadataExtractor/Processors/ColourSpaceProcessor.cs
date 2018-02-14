namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ColourSpaceProcessor : IErrorableMetaDataElementProcessor
    {
        public string Error => "Unknown Colour Space value:{0:X4}";

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
                Log?.Warning(string.Format(Error,propertyValue));
            }
        }
    }
}