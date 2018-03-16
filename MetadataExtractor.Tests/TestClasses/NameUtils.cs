namespace MetadataExtractor.Tests.TestClasses
{
    using System.Linq;

    public static class NameUtils
    {
        public static string GetNameFromProcessor(ISupportQueries processor)
        {
            return FromPascalCase(FromProcessor(processor));
        }

        private static string FromPascalCase(this string pascalCase)
        {
            var toReplace = pascalCase.Where(char.IsUpper);
            return toReplace.Aggregate(pascalCase, (current, item) => current.Replace(item.ToString(), " " + char.ToLower(item))).Trim();
        }

        private static string FromProcessor(ISupportQueries processor)
        {
            return processor.GetType().Name.Replace("Processor", string.Empty);
        }
    }
}