using System;
using System.IO;

namespace Training4
{
    public static class FileSearcher
    {
        public static void SearchTxtFile (string partialFileName, string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] subDirectories = directory.GetDirectories();

            FileInfo[] includedFiles = directory.GetFiles();
            foreach (var file in includedFiles)
            {
                if (file.Name.Contains(partialFileName) && file.Extension == ".txt")
                {
                    Console.WriteLine(file.FullName);
                    return;
                }
            }
        }
    }
}