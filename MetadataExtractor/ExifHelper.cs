namespace MetadataExtractor
{
    using System;
    using System.Text;

    public static class ExifHelper
    {
        public static byte GetByte(ExifProperty item)
        {
            return item.Value[0];
        }

        public static string GetString(ExifProperty item)
        {
            return Encoding.ASCII.GetString(item.Value).Trim('\0');
        }

        public static decimal GetRational(ExifProperty item, int index)
        {
            var nominator = BitConverter.ToUInt32(item.Value, 8 * index);
            var denominator = BitConverter.ToUInt32(item.Value, 8 * index + 4);
            return nominator / (decimal) denominator;
        }

        public static decimal GetRational(ExifProperty item)
        {
            var nominator = BitConverter.ToUInt32(item.Value, 0);
            var denominator = BitConverter.ToUInt32(item.Value, 4);
            return nominator / (decimal) denominator;
        }

        public static decimal GetSignedRational(ExifProperty item)
        {
            var nominator = BitConverter.ToInt32(item.Value, 0);
            var denominator = BitConverter.ToInt32(item.Value, 4);
            return nominator / (decimal) denominator;
        }

        public static ushort GetShort(ExifProperty property)
        {
            return BitConverter.ToUInt16(property.Value, 0);
        }

        public static uint GetLong(ExifProperty property)
        {
            return BitConverter.ToUInt32(property.Value, 0);
        }

        public static int GetSignedShort(ExifProperty property)
        {
            return BitConverter.ToInt16(property.Value, 0);
        }

        public static int GetSignedLong(ExifProperty property)
        {
            return BitConverter.ToInt32(property.Value, 0);
        }
    }
}