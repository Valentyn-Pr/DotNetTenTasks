using System;

namespace Training3
{
    public class StackOverflowGenerator
    {
        public void GetStackOverflowException()
        {
            do
            {
                double x = 0;
                GetStackOverflowException();
            }
            while (true); 
        }

    }
}
