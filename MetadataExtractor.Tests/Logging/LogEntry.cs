namespace MetadataExtractor.Tests.Logging
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class LogEntry
    {
        public string Level { get; set; }
        public string Message { get; set; }
    }
}