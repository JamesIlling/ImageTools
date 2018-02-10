namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class OrientationProcessor : IMetaDataElementProcessor
    {
        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0x0112;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(OrientationEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.Orientation = (OrientationEnum) propertyValue;
            }
            else
            {
                Log?.Info("Orientation Value:0x" + propertyValue.ToString("X4"));
            }
        }
    }
}