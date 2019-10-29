using Training7;

namespace Completed_Taks
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(10, 10, 0, 0);
            System.Console.WriteLine(rec.GetRectangleCreatedByCrossingWithRectangle(new Rectangle(4,10,6,0)).Height);
        }
    }
}