namespace MetadataExtractor.Processors
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Unity.Attributes;

    public class FlashProcessor : EnumProcessor<StrobeReturnEnum>, ISupportErrorableQueries
    {
        private static readonly List<ushort> Valid = new List<ushort>
        {
            0x0000,
            0x0001,
            0x0005,
            0x0007,
            0x0008,
            0x0009,
            0x000D,
            0x000F,
            0x0010,
            0x0014,
            0x0018,
            0x0019,
            0x001d,
            0x001f,
            0x0020,
            0x0030,
            0x0041,
            0x0045,
            0x0047,
            0x0049,
            0x004D,
            0x004F,
            0x0050,
            0x0058,
            0x0059,
            0x005D,
            0x005F
        };

        public string Error => "Unknown flash value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=37385}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                if (!Valid.Contains((ushort) property))
                {
                    Log.Warning(string.Format(Error, property));
                    return;
                }

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
}