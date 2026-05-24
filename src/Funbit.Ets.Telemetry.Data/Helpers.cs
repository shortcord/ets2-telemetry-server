using System;
using System.IO;
using System.Text;

namespace Funbit.Ets.Telemetry.Data
{
    public static class Helpers
    {
        public static DateTime SecondsToDate(this int seconds)
        {
            if (seconds < 0) seconds = 0;
            return new DateTime((long)seconds * 10000000, DateTimeKind.Utc);
        }

        public static DateTime SecondsToDate(this long seconds)
        {
            if (seconds < 0) seconds = 0;
            return new DateTime(seconds * 10000000, DateTimeKind.Utc);
        }
        
        public static DateTime MinutesToDate(this int minutes)
        {
            return SecondsToDate(minutes * 60);
        }

        public static DateTime MinutesToDate(this long minutes)
        {
            return SecondsToDate(minutes * 60);
        }

        public static string BytesToString(this byte[]? bytes)
        {
            return bytes == null
                ? string.Empty
                : Encoding.UTF8.GetString(bytes,
                    0,
                    Array.FindIndex(bytes,
                        b => b == 0));
        }
    }
}
