using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;

namespace Tests
{
    [TestClass]
    public class ExtensionTest
    {
        private enum TimeMethod
        {
            MilliSeconds, Seconds, Minutes, Hours, Days
        }
        private TimeSpan TimeGenerator (TimeMethod time)
        {
            Random rand = new Random();
            int value = rand.Next(0, 100000);
            Console.WriteLine(value);
            switch(time)
            {
                case TimeMethod.MilliSeconds: return value.MilliSeconds();
                case TimeMethod.Seconds: return value.Seconds();
                case TimeMethod.Minutes: return value.Minutes();
                case TimeMethod.Hours: return value.Hours();
                case TimeMethod.Days: return value.Days();
                default: return 0.MilliSeconds();
            }
        }

        [TestMethod]
        public void IntValueToMilliSeconds()
        {
            TimeSpan t = TimeGenerator(TimeMethod.MilliSeconds);
            Console.WriteLine(t);
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void IntValueToSeconds()
        {
            TimeSpan t = TimeGenerator(TimeMethod.Seconds);
            Console.WriteLine(t);
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void IntValueToMinutes()
        {
            TimeSpan t = TimeGenerator(TimeMethod.Minutes);
            Console.WriteLine(t);
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void IntValueToHours()
        {
            TimeSpan t = TimeGenerator(TimeMethod.Hours);
            Console.WriteLine(t);
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void IntValueToDays()
        {
            TimeSpan t = TimeGenerator(TimeMethod.Days);
            Console.WriteLine(t);
            Assert.IsNotNull(t);
        }
    }
}
