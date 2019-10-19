using System;
using System.Collections.Generic;
using System.Text;

namespace Training3
{
    public class IndexOutOfRangeExceptionGenerator
    {
        int[] array = new int[2];

        public void GetIndexOutOfRangeException()
        {
            int temp = array[2];
        }

    }
}
