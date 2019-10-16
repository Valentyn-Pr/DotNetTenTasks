using System;
using Log;
using Microsoft.Extensions.Configuration;

namespace Completed_Taks
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int x = 5;
                int y = 0;
                x = x / y;
            }
            catch (Exception e)
            {
                Logger logger = Logger.getLogger();
                logger.Write(e);
            }
        }
    }
}
