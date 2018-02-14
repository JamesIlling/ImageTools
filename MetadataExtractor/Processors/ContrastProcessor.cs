namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class ContrastProcessor : IErrorableMetaDataElementProcessor
    {
        public string Error =>"Unknown Contrast value:{0:X4}";

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
                Log?.Warning(string.Format(Error,propertyValue));
            }
        }
    }
}