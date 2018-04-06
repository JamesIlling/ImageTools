namespace ImageTools.Options
{
    using CommandLine;

    [Verb("Extract")]
    public class ExtractOptions
    {
        [Option('f', "file", Required = true, HelpText = "The file to extract metadata from.")]
        public string File { get; set; }
    }
}