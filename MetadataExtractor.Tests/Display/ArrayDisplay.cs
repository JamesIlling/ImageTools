namespace MetadataExtractor.Tests.Display
{
    using System.Linq;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public  class ArrayDisplay<T> : IDisplay
    {
        public bool Supported(object value)
        {
            return value is T[];
        }

        public string GetText(object value)
        {
            var itemTexts = (from item in value as T[] select item.ToString()).ToList();
            return string.Join(", ", itemTexts);
        }
    }
}