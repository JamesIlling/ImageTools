namespace ImageTools
{
    using System;
    using MetadataExtractor;
    using MetadataExtractor.Processors;

    public class ConsoleLog : ILog
    {

        public void Warning(string message)
        {
            Console.WriteLine("Warning:" + message);
        }

        public void Error(Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message +" at" +ex.StackTrace);
        }
    }
}