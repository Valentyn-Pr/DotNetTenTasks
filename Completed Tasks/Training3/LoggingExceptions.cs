using System;
using NLog;

namespace Training3
{
    public class ExceptionsLogging
    {
        public void GenerateAndLogIndexOutOfRangeException()
        {
            try
            {
                var indOfRange = new IndexOutOfRangeExceptionGenerator();
                indOfRange.GetIndexOutOfRangeException();
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e);
            }
        }

        public void GenerateAndLogArgumentExceptions()
        {
            try
            {
                var indOfRange = new IndexOutOfRangeExceptionGenerator();
                indOfRange.GetIndexOutOfRangeException();
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e);
            }

            try
            {
                var indOfRange = new IndexOutOfRangeExceptionGenerator();
                indOfRange.GetIndexOutOfRangeException();
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e);
            }
        }

        // do this method PRIVATE
        // public is only for testing
        public void DoSomeMath(int a, int b) 
        {
            if (a < 0)
            {
                throw new ArgumentException("Parameter should be greater than 0", "a");
            }
            
            if (b > 0)
            {
                throw new ArgumentException("Parameter should be less than 0", "b");
            }
        }
    }
}
