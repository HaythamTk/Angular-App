using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal static class InestanceMethod
    {
      
        public static bool IsWeekEnd(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Friday || value.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
