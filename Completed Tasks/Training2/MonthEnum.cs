using System;
using System.Collections.Generic;
using System.Text;

namespace Training2
{
    enum Month { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }
    public class MonthEnum
    {
        public string GetMonthByNumber (int n)
        {
            return (n >= 0 && n < 12) ? Enum.GetName(typeof(Month), n) : throw new InvalidArgumentException("not correct month number!");
        }
    }
}
