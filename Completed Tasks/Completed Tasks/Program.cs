using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Training4;

namespace Completed_Taks
{
    class Program
    {
        static void Main(string[] args)
        {
            var qwerty = new DirectoryInfoReader();
            qwerty.GetAllDirectoryInfo(@"C:\Users\Valentyn\Desktop\gitHUB");

        }
    }
}
