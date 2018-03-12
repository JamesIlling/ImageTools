﻿namespace MetadataExtractor
{
    using System;

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

        public static ushort GetShort(object property)
        {
            if (property is byte)
            {
                return Convert.ToUInt16(property);
            }
            return (ushort) property;
        }

        public static uint GetLong(object property)
        {
            return (uint) property;
        }
    }
}