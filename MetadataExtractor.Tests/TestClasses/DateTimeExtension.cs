namespace MetadataExtractor.Tests.TestClasses
{
    using System;

    public static class DateTimeExtension
    {
        public static DateTime ToNearestSecond(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
        }
    }
}