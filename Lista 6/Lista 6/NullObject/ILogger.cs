using System;
using System.IO;

namespace Lista_6.NullObject
{
    public interface ILogger
    {
        void Log(string message);
    }

    internal class FileLogger : ILogger
    {
        readonly string filepath;
        public FileLogger(string filepath)
        {
            this.filepath = filepath;
        }

        public void Log(string message)
        {
            using (var sWriter = new StreamWriter(filepath))
            {
                sWriter.WriteLine(message);
            }
        }

        ~FileLogger()
        {
        }
    }

    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}