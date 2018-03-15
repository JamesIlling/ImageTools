namespace MetadataExtractor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Media.Imaging;

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

                var prop = value as BitmapMetadataBlob;
                if (prop == null)
                {
                    log?.Warning(string.Format(error, propertyValue));
                }
            }
            return null;
        }
    }
}