using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockC_
{
     class Time
    {
        public int Hour = 0, Second = 0, Minute = 0, Milliseconds = 0;
        public Time(int hours, int minute, int second, int milliseconds)
        {
            {
                Hour = hours;
                Second = second;
                Minute = minute;
                Milliseconds = milliseconds;
            }
        }
    }
}
