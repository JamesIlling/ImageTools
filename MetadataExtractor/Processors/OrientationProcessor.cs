namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class OrientationProcessor : IMetaDataElementProcessor
    {        
        public const string Error = "Unknown Orientation value:{0:X4}";

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
                Log?.Warning(string.Format(Error,propertyValue));
            }
        }
    }
}