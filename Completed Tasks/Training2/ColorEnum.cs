using System;
using System.Collections.Generic;
using System.Linq;

namespace Training2
{
    public enum Colors { Red = 4, Blue = 15, Green = 1 };
    public static class ColorEnum
    {
        public static void GetValuesASC (this Colors colors, Action<string> print)
        {
            var sortedList = new List<int>();

            foreach (int colorValue in Enum.GetValues(typeof(Colors)))
            {
                sortedList.Add(colorValue);
            }

            sortedList.Sort();

            foreach (int colorValue in sortedList)
            {
                print($"{Enum.GetName(typeof(Colors),colorValue)} = {colorValue}");
            }
        }
    }
}
