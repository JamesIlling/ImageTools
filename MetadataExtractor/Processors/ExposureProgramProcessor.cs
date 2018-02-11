namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ExposureProgramProcessor : IMetaDataElementProcessor
    {
        public const string Error = "Unknown Exposure program value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }
        public int Id => 0x8822;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(ExposureProgramEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.ExposureProgram = (ExposureProgramEnum)propertyValue;
            }
            else
            {
                Log?.Warning(string.Format(Error, propertyValue));
            }
        }
    }
}