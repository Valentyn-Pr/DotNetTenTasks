using System;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Variant2
{
    public class UnigueFiles
    {
        public List<string> DuplicatedFiles = new List<string>();
        public int DuplicatedFilesCounter { get; private set; } = 0;
        public string ElapsedTime { get; private set; }
        public Hashtable UnigueFilesTable = new Hashtable();

        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        public void GetInfoAndElapsedTime()
        {
            stopwatch.Start();
            GetAllDirectoryInfo(@"C:\Users\Valentyn\Desktop\New folder");
            ElapsedTime = stopwatch.ElapsedMilliseconds.ToString();

            Console.WriteLine("List of unigue files:");
            foreach (var element in UnigueFilesTable.Values)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine($"Number of duplicated files: {DuplicatedFilesCounter}");
            Console.WriteLine("Duplicated files:");
            foreach (var element in DuplicatedFiles)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Elapsed Time for this task: {ElapsedTime} ms");
        }

        private void GetAllDirectoryInfo(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] subDirectories = directory.GetDirectories();

            FileInfo[] includedFiles = directory.GetFiles();
            foreach (var file in includedFiles)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = file.OpenRead())
                    {
                        try
                        {
                            var hash = md5.ComputeHash(stream);
                            UnigueFilesTable.Add(BitConverter.ToString(hash), file.FullName);
                        }
                        catch (ArgumentException e)
                        {
                            DuplicatedFiles.Add(file.Name);
                            DuplicatedFilesCounter++;
                        }
                    }
                }
            }

            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                if (subDirectory.GetDirectories().Length != 0 || subDirectory.GetFiles().Length != 0)
                {
                    GetAllDirectoryInfo(subDirectory.FullName);
                }
            }
        }
    }
}