namespace MetadataExtractor
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Media.Imaging;

    public static class ExifHelper
    {
        public static string GetString(object item)
        {
            if (item != null)
            {
                var text = item as string;
                return text?.Trim('\0');
            }
            return null;
        }

        public static decimal? GetRational(object item)
        {
            if (item != null)
            {
                var value = (ulong) item;
                var nominator = value & uint.MaxValue;
                var denominator = value >> 32;
                return nominator / (decimal) denominator;
            }
            return null;
        }

        public static decimal? GetSignedRational(object item)
        {
            if (item != null)
            {
                var value = (long) item;
                var nominator = BitConverter.ToInt32(BitConverter.GetBytes(value & uint.MaxValue), 0);
                var denominator = Convert.ToInt32(value >> 32);
                return nominator / (decimal) denominator;
            }
            return null;
        }

        public static ushort? GetShort(object property)
        {
            if (property != null)
            {
                return Convert.ToUInt16(property);
            }
            return null;
        }

        public static uint? GetLong(object property)
        {
            if (property != null)
            {
                return (uint) property;
            }
            return null;
        }

        public static string GetStringFromBlob(object property)
        {
            if (property != null)
            {
                if (property is BitmapMetadataBlob prop)
                {
                   return string.Join(".", Encoding.ASCII.GetString(prop.GetBlobValue()).ToArray().Select(x => x.ToString()));
                }
            }
            return null;
        }
    }
}