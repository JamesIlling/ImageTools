namespace ImageTools
{
    using System;
    using System.IO;
    using System.Linq;
    using DependencyFactory;
    using MetadataExtractor;

    internal class Program
    {
        private static void Main(string[] args)
        {
            RegisterDependencies();

            var metadata =
                ExtractFromFile(@"C:\Users\James\Source\Repos\ImageTools\MetadataExtractor.Tests\Resources\ACDSee.jpg");


            var displayer = DependencyInjection.Resolve<IDisplay>();
            displayer.Display(metadata);
        }

        private static void RegisterDependencies()
        {
            DependencyInjection.RegisterType<ILog, ConsoleLog>();
            DependencyInjection.RegisterType<IGetProcessors, ReflectionHelper>();
            DependencyInjection.RegisterType<IDisplay, ConsoleDisplayer>();
        }

        private static void DisplayProcessors()
        {
            var processorLocator = DependencyInjection.Resolve<IGetProcessors>();
            var processors = processorLocator.GetAll().OrderBy(x => x.Id);
            foreach (var processor in processors)
            {
                Console.Write(processor.Id.ToString("X4"));
                Console.Write(":");
                Console.WriteLine(processor.GetType().Name.Replace("Processor", ""));
            }
        }

        private static Metadata ExtractFromFile(string path)
        {
            var extractor = DependencyInjection.Resolve<Extractor>();
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