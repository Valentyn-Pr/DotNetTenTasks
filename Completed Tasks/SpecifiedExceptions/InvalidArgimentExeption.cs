using System;
using System.Collections.Generic;
using System.Text;

namespace Training2
{
    public class InvalidArgimentException : Exception
    {
        public InvalidArgimentException(): this ("Invalid argument(s)")
        { }

        public InvalidArgimentException(string message)
        : base(message)
        { }
    }
}
