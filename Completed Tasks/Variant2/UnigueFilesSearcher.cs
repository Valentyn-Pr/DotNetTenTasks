using System;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace Variant2
{
    public partial class UnigueFilesSearcher
    {
        int excelFileCurrentRowCounter = 1;
        string path;
        string resultFile;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        public UnigueFilesSearcher()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("UnigueFilesSearcherConfiguration.json", optional: true, reloadOnChange: true);

            IConfigurationRoot config = builder.Build();

            path = config["FilePath"];
            resultFile = config["ResultFile"];
            var displaySource = config["DisplaySource"].ToLower();

            if (displaySource == "console")
            {
                writingSource = WriteToConsole;
            }
            else if (displaySource == "file")
            {
                writingSource = WriteToFile;
                using (var excelFile = new ExcelPackage())
                {
                    var ws = excelFile.Workbook.Worksheets.Add("Results");
                    excelFile.SaveAs(new FileInfo(resultFile + "//result.xlsx"));
                }
            }
            else throw new ArgumentException("Invalid config file");
        }

        delegate void Source(string message);
        Source writingSource;

        public int DuplicatedFilesCounter { get; private set; } = 0;
        public string ElapsedTime { get; private set; }
        public Hashtable UnigueFilesTable { get; private set; } = new Hashtable();
        public Dictionary<string, string> DuplicatedFiles { get; private set; } = new Dictionary<string, string>();

        void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
        void WriteToFile(string message)
        {
            using (var excelPackage = new ExcelPackage(new FileInfo(resultFile + "//result.xlsx")))
            {
                var workSheet = excelPackage.Workbook.Worksheets[0];

                workSheet.Cells[$"A{excelFileCurrentRowCounter}"].Value = message;
                excelFileCurrentRowCounter++;
                excelPackage.Save();
            }
        }
        public void GetInfoAndElapsedTime()
        {
            stopwatch.Start();
            GetUnigueAndDuplicatedFiles(path);
            ElapsedTime = stopwatch.ElapsedMilliseconds.ToString();

            writingSource("List of unigue files:");
            foreach (var unigueFile in UnigueFilesTable.Values)
            {
                writingSource(unigueFile.ToString());
            }

            writingSource($"Number of duplicated files: {DuplicatedFilesCounter}");
            writingSource("Duplicated files:");
            // TODO: add duplicated pair
            foreach (var duplicatedFile in DuplicatedFiles)
            {
                writingSource(duplicatedFile.Value);
                writingSource(" duplicate with -> " + UnigueFilesTable[duplicatedFile.Key]);
            }

            writingSource($"Elapsed Time: {ElapsedTime} ms");
        }
        private void GetUnigueAndDuplicatedFiles(string path)
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
                        string hashKey = "";
                        try
                        {
                            var hash = md5.ComputeHash(stream);
                            hashKey = BitConverter.ToString(hash);
                            UnigueFilesTable.Add(hashKey, file.FullName);
                        }
                        catch (ArgumentException)
                        {
                            DuplicatedFiles.Add(hashKey, file.FullName);
                            DuplicatedFilesCounter++;
                        }
                    }
                }
            }

            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                if (subDirectory.GetDirectories().Length != 0 || subDirectory.GetFiles().Length != 0)
                {
                    GetUnigueAndDuplicatedFiles(subDirectory.FullName);
                }
            }
        }
    }
}