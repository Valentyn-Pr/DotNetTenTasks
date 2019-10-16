using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Log
{
    /// <summary>
    /// Implements Singleton
    /// use getLogger to get instance of class
    /// </summary>
    public class Logger : ILogger
    {
        private static readonly Lazy<Logger> singletonInstance =
            new Lazy<Logger>(() => new Logger());

        string logFilePath = "";

        int detalizationLevel = 0;

        delegate void Source(string message);
        Source writingSource;

        #region Constructors
        private Logger()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("loggersettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot config = builder.Build();

            this.logFilePath = config["logFilePath"] + @"\log.txt";
            this.detalizationLevel = int.Parse(config["detalizationLevel"]);

            if (config["logSource"].ToLower() == "console")
            {
                writingSource = WriteLogToConsole;
            }
            else
            {
                writingSource = WriteLogToFile;
            }
        }
        #endregion

        public static Logger getLogger()
        {
            return singletonInstance.Value;
        }

        void WriteLogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        void WriteLogToFile(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFilePath, true, System.Text.Encoding.Default))
            {
                streamWriter.WriteLine(message);
            }
        }

        // TODO: replace int by enum
        public void Write(Exception exception)
        {
            string message = "";
            if (detalizationLevel >= 0)
            {
                message = "Exception message: " + exception.Message + " \r\n";
            }

            if (detalizationLevel >= 1)
            {
                message += "Exception source: " + exception.Source + " \r\n";
                message += "Exception target site: " + exception.TargetSite + " \r\n";
            }

            if (detalizationLevel >= 2)
            {
                message += "Exception stack trace: " + exception.StackTrace + " \r\n";
                message += "Exception HResult: " + exception.HResult + " \r\n";
            }

            writingSource(message);
        }

        public void Read()
        {
            using (StreamReader streamReader = new StreamReader(logFilePath))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
}