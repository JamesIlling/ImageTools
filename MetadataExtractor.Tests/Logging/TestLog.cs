namespace MetadataExtractor.Tests.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class TestLog : ILog
    {
        public List<LogEntry> Messages { get; } = new List<LogEntry>();


        public void Warning(string message)
        {
            Messages.Add(new LogEntry {Level = "Warning", Message = message});
        }

        public void Error(Exception ex)
        {
            Messages.Add(new LogEntry {Level = "Error", Message = ex.Message + " at" + ex.StackTrace});
        }
    }
}