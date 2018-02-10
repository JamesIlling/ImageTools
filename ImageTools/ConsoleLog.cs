namespace ImageTools
{
    using System;
    using MetadataExtractor.Processors;

    public class ConsoleLog : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine("Debug:" + message);
        }

        public void Info(string message)
        {
            Console.WriteLine("Info:" + message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("Warning:" + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("Error:" + message);
        }
    }
}