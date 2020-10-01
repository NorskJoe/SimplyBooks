using System;

namespace SimplyBooks.Domain.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset ToLocalDateTimeOffset(this DateTimeOffset input)
        {
            return input.ToLocalTime();
        }

        public static DateTime ToLocalDateTime(this DateTimeOffset input)
        {
            return input.ToLocalDateTimeOffset().DateTime;
        }

        public static string ToShortDateString(this DateTimeOffset input)
        {
            return input.ToLocalDateTime().ToShortDateString();
        }
    }
}
