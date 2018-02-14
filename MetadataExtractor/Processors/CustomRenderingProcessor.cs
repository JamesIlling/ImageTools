namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class CustomRenderingProcessor : IErrorableMetaDataElementProcessor
    {
        public string Error => "Unknown Custom Rendering value:{0:X4}";
        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0xA401;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var enumValues = Enum.GetValues(typeof(CustomRenderingEnum)).Cast<ushort>();
            var propertyValue = ExifHelper.GetShort(property);
            if (enumValues.Contains(propertyValue))
            {
                metadata.CustomRendering = (CustomRenderingEnum) propertyValue;
            }
            else
            {

                Log?.Warning(string.Format(Error,propertyValue));
            }
        }
    }
}