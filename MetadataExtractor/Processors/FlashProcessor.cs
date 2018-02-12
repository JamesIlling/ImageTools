namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class FlashProcessor : IMetaDataElementProcessor
    {
        public const string FiringModeError = "Unknown Firing Mode value:{0:X4}";
        public const string StrobeReturnError = "Unknown Strobe Return value:{0:X4}";
        [Dependency]
        public ILog Log { get; set; }

        public int Id => 0x9209;

        public void Process(Metadata metadata, ExifProperty property)
        {
            ushort val = 0x0001;
            var value = ExifHelper.GetShort(property);
            metadata.FlashFired = (Convert.ToInt32(value) & val) != 0x0000;

            val = 0x0006;
            var strobePropertyValue = (ushort)(value & val);
            var strobReturnValues = Enum.GetValues(typeof(StrobeReturnEnum)).Cast<ushort>();
            if (strobReturnValues.Contains(strobePropertyValue))
            {
                metadata.StrobeReturn = (StrobeReturnEnum)strobePropertyValue;
            }
            else
            {
                Log?.Warning(string.Format(StrobeReturnError, strobePropertyValue));
            }

            val = 0x0018;
            var firingModePropertyValue = (ushort)(value & val);
            metadata.FiringMode = (FiringModeEnum)firingModePropertyValue;

            val = 0x0020;
            metadata.FlashFunction = (Convert.ToInt32(value) & val) == 0x0000;

            val = 0x0040;
            metadata.RedEyeReduction = (Convert.ToInt32(value) & val) != 0x0000;
        }
    }
}