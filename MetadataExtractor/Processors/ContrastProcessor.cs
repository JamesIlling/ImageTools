namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ContrastProcessor : IMetaDataElementProcessor
    {
        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0xA408;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(ContrastEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.Contrast = (ContrastEnum) propertyValue;
            }
            else
            {
                Log?.Info("Contrast Value:0x" + propertyValue.ToString("X4"));
            }
        }
    }
}