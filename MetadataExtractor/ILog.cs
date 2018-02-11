namespace MetadataExtractor
{
    using System;

    public interface ILog
    {
        void Warning(string message);
        void Error(Exception ex);
    }
}