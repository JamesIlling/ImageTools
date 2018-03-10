namespace MetadataExtractor
{
    using System;
    using System.Globalization;
    using System.Linq;

    public abstract class EnumProcessor<T> where T : struct, IConvertible, IComparable, IFormattable
    {

        public T? Process(object value, ILog log, string error)
        {
            if (value != null)
            {
                var enumValues = Enum.GetValues(typeof(T)).Cast<T>();
                var propertyValue = ExifHelper.GetShort(value);
                var conversion = enumValues.Where(x => x.ToUInt32(CultureInfo.CurrentCulture) == propertyValue).ToList();
                if (conversion.Any())
                {
                    return conversion.First();
                }
                log?.Warning(string.Format(error, propertyValue));
            }
            return null;
        }
    }
}