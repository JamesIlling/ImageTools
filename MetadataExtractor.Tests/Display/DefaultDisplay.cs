namespace MetadataExtractor.Tests.Display
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class DefaultDisplay :IDisplay
    {
        public bool Supported(object value)
        {
            return true;
        }

        public string GetText(object value)
        {
            return value.ToString();
        }
    }
}