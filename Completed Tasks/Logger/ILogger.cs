using System;

namespace Log
{
    interface ILogger
    {
        void Read();
        void Write(Exception exeption);
    }
}
