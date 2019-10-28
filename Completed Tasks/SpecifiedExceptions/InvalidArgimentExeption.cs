namespace Training2
{
    using System;

    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(): this ("Invalid argument(s)")
        { }

        public InvalidArgumentException(string message)
        : base(message)
        { }
    }
}