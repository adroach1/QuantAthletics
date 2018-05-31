using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Core.Utilities
{
    public static class DateUtil
    {
        public static int GetWeekOfYear(DateTime date)
        {
            return date.DayOfYear/7;
        }
    }
}
