namespace MetadataExtractor.Processors
{
    public interface ILog
    {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}