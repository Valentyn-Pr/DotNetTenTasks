namespace Training3
{
    public class StackOverflowGenerator
    {
        public void GetStackOverflowException()
        {
            do
            {
                double x = 0;
                this.GetStackOverflowException();
            }
            while (true); 
        }
    }
}