using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public static class IntExtention
    {
        public static TimeSpan MilliSeconds(this int value)
        {
            return new TimeSpan(0, 0, 0, 0, Math.Abs(value));
        }

        public static TimeSpan Seconds (this int value)
        {
            return new TimeSpan(0, 0, 0, Math.Abs(value), 0);
        }

        public static TimeSpan Minutes (this int value)
        {
            return new TimeSpan(0, 0, Math.Abs(value), 0, 0);
        }

        public static TimeSpan Hours (this int value)
        {
            return new TimeSpan(0, Math.Abs(value), 0, 0, 0);
        }

        public static TimeSpan Days (this int value)
        {
            return new TimeSpan(Math.Abs(value), 0, 0, 0, 0);
        }
    }
}
