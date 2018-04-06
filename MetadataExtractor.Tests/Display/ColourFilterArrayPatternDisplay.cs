namespace MetadataExtractor.Tests.Display
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Enums;

    [ExcludeFromCodeCoverage]
    public class ColourFilterArrayPatternDisplay : IDisplay
    {
        public bool Supported(object value)
        {
            return value is ColourFilterArray[,];
        }

        public string GetText(object value)
        {
            var array = value as ColourFilterArray[,];
            var height = array.GetLength(0);
            var width = array.GetLength(1);
            var columns = new List<string>();
            for (var row = 0; row < height; row++)
            {
                var content = new List<string>();
                for (var column = 0; column < width; column++)
                {
                    content.Add(array[row, column].ToString());
                }

                columns.Add($"[{string.Join(", ", content)}]");
            }

            return $"[{string.Join(", ", columns)}]";
        }
    }
}