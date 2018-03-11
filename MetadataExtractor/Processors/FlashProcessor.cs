namespace MetadataExtractor.Processors
{
    using System;
    using Enums;
    using Unity.Attributes;

    public class FlashProcessor : EnumProcessor<StrobeReturnEnum>, ISupportQueries
    {
        public string Error => "Unknown Strobe Return value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=37385}";

        public void Process(Metadata metadata, object property)
        {
            ushort val = 0x0001;
            var value = ExifHelper.GetShort(property);
            metadata.FlashFired = (Convert.ToInt32(value) & val) != 0x0000;

            val = 0x0006;
            var strobePropertyValue = (ushort) (value & val);
            metadata.StrobeReturn = Process(strobePropertyValue, Log, Error);

            val = 0x0018;
            var firingModePropertyValue = (ushort) (value & val);
            metadata.FiringMode = (FiringModeEnum) firingModePropertyValue;

            val = 0x0020;
            metadata.FlashFunction = (Convert.ToInt32(value) & val) == 0x0000;

            val = 0x0040;
            metadata.RedEyeReduction = (Convert.ToInt32(value) & val) != 0x0000;
        }
    }
}