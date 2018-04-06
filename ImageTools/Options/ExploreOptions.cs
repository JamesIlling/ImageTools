namespace ImageTools.Options
{
    using CommandLine;

    [Verb("Explore")]
    public class ExploreOptions
    {
        [Option('f', "file", Required = true, HelpText = "The file to explore.")]
        public string File { get; set; }

        [Option('u', "Unknown", Default = false, HelpText = "Show only unknown fields")]
        public bool UnknownOnly { get; set; }

        [Option('m', "MapToProcessors", Default = false, HelpText = "Map the metadata names to processors")]
        public bool MapToProcessors { get; set; }
    }
}