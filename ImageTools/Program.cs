namespace ImageTools
{
    using System;
    using System.IO;
    using System.Linq;
    using MetadataExtractor;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //DisplayProcessors();
            var metadata = ExtractFromFile(@"E:\DSC_5233.jpg");
            ReflectionHelper.Display(metadata);
        }

        private static void DisplayProcessors()
        {
            var processors = ReflectionHelper.GetAll<IMetaDataElementProcessor>().OrderBy(x => x.Id);
            foreach (var processor in processors)
            {
                Console.Write(processor.Id.ToString("X4"));
                Console.Write(":");
                Console.WriteLine(processor.GetType().Name.Replace("Processor", ""));
            }
        }

        private static Metadata ExtractFromFile(string path)
        {
            var extractor = new Extractor();
            if (File.Exists(path))
            {
                using (var file = File.OpenRead(path))
                {
                    return extractor.Extract(file);
                }
            }
            return null;
        }
    }
}