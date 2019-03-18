using System;

namespace CallReminder.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static long ToCurrentTimeMillis(this DateTime date)
        {
            TimeSpan ts = (date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            return (long)ts.TotalMilliseconds;
        }
    }
}
