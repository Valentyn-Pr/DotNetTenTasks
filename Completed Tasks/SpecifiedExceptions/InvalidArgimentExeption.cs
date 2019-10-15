using System;
using System.Collections.Generic;
using System.Text;

namespace Training2
{
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(): this ("Invalid argument(s)")
        { }

        public InvalidArgumentException(string message)
        : base(message)
        { }
    }
}
