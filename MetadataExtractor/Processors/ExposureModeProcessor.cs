namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ExposureModeProcessor : IMetaDataElementProcessor
    {
        public const string Error = "Unknown Exposure mode value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0xA402;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(ExposureModeEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.ExposureMode = (ExposureModeEnum) propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}