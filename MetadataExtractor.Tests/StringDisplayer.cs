namespace MetadataExtractor.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using Display;
    using Enums;

    [ExcludeFromCodeCoverage]
    public class StringDisplayer
    {
        private readonly List<IDisplay> _complexFields = new List<IDisplay>
        {
            new ArrayDisplay<decimal?>(),
            new ArrayDisplay<ushort>(),
            new ArrayDisplay<ComponentConfiguration>(),
            new ColourFilterArrayPatternDisplay(),
            new DefaultDisplay()
        };

        public string Read<T>(T obj)
        {
            var text = new StringBuilder();
            if (obj == null)
            {
                return text.ToString();
            }

            foreach (var property in typeof(T).GetProperties().OrderBy(x => x.Name))
            {
                var value = property.GetValue(obj);
                if (value == null)
                {
                    continue;
                }

                text.Append(property.Name);
                text.Append(":");

                foreach (var displayer in _complexFields)
                {
                    if (displayer.Supported(value))
                    {
                        text.AppendLine(displayer.GetText(value));
                        break;
                    }
                }
            }

            return text.ToString();
        }
    }
}