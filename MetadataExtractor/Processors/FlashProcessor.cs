namespace MetadataExtractor.Processors
{
    using System;

    internal class FlashProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9209;

        public void Process(Metadata metadata, ExifProperty property)
        {
            var val = 0x0001 << 0;
            var value = ExifHelper.GetShort(property);
            metadata.FlashFired = (Convert.ToInt32(value) & val) != 0x0000;

            val = 0x0001 << 5;
            metadata.FlashFunction = (Convert.ToInt32(value) & val) == 0x0000;

            val = 0x0001 << 6;
            metadata.RedEyeReduction = (Convert.ToInt32(value) & val) != 0x0000;

            val = 0x0011 << 1;
            metadata.StrobeReturn = (StrobeReturnEnum) (Convert.ToInt32(value) & val);

            val = 0x0011 << 3;
            metadata.FiringMode = (FiringModelEnum) (Convert.ToInt32(value) & val);
        }
    }
}