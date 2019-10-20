using System;
using System.IO;

namespace Training4
{
    public class DirectoryInfoReader
    {
        int tabCounter = 1;
        public void GetAllDirectoryInfo(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            Console.WriteLine(new String('*', tabCounter) + directory.Name);

            DirectoryInfo[] subDirectories = directory.GetDirectories();

            FileInfo[] includedFiles = directory.GetFiles();
            foreach (var file in includedFiles)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(new String('>', tabCounter) + file.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }

            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                Console.WriteLine(new String('*', tabCounter) + subDirectory.Name);
                if (subDirectory.GetDirectories().Length != 0)
                {
                    tabCounter++;
                    GetAllDirectoryInfo(subDirectory.FullName);
                    tabCounter--;
                }
            }  
        }
    }
}