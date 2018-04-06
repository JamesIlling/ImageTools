namespace MetadataExtractor.Tests.TestClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    [ExcludeFromCodeCoverage]
    public static class Enum<TEnum, TBase> where TEnum : struct, IConvertible

    {
        public static IEnumerable<TBase> Values()
        {
            return typeof(TEnum).IsEnum
                ? Enum.GetValues(typeof(TEnum)).Cast<TBase>()
                : Enumerable.Empty<TBase>();
        }

        public static TBase GetInvalidValue()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidCastException("The specified Type is not an Enum");
            }

            try
            {
                var all = Enumerable.Range(GetBaseMin(), GetBaseMax()).Select(ConvertToBase);
                var invalid = all.Except(Values()).ToList();
                return invalid.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new InvalidCastException("The type of TBase does not match the Enum type", e);
            }
        }

        private static TBase ConvertToBase(int value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TBase));
            if (converter.CanConvertFrom(value.GetType()))
            {
                return (TBase) converter.ConvertFrom(value);
            }

            converter = TypeDescriptor.GetConverter(typeof(int));
            if (converter.CanConvertTo(typeof(TBase)))
            {
                return (TBase) converter.ConvertTo(value, typeof(TBase));
            }

            return default(TBase);
        }

        private static int GetBaseMin()
        {
            return Convert.ToInt32(typeof(TBase)
                .GetField("MinValue", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                ?.GetRawConstantValue());
        }

        private static int GetBaseMax()
        {
            return Convert.ToInt32(typeof(TBase)
                .GetField("MaxValue", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                ?.GetRawConstantValue());
        }

        public static TEnum? Value(TBase item)
        {
            if (item != null)
            {
                var type = Enum.GetUnderlyingType(typeof(TEnum));
                var converter = TypeDescriptor.GetConverter(type);
                var convertTo = converter.ConvertTo(item, type);
                if (convertTo != null)
                {
                    return (TEnum) convertTo;
                }
            }

            return null;
        }
    }
}