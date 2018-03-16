using System.Linq;
using MetadataExtractor.Tests;

namespace ImageTools
{
    using System.IO;
    using DependencyFactory;
    using MetadataExtractor;

    internal class Program
    {
        private static void Main(string[] args)
        {
            RegisterDependencies();
            var explorer = DependencyInjection.Resolve<IExploreMetadata>();
            foreach (var image in TestResources.All())
            {
                var elements= explorer.GetUnknownElements(image.Value);
                File.WriteAllLines($@"e:\{image.Key}.txt", elements.Select(x => x.Type.PadRight(20, ' ') + ":" + x.Query));
            }                       
        }

        private static void RegisterDependencies()
        {
            DependencyInjection.RegisterType<ILog, ConsoleLog>();
            DependencyInjection.RegisterType<IGetProcessors, ReflectionHelper>();
            DependencyInjection.RegisterType<IDisplay, ConsoleDisplayer>();
            DependencyInjection.RegisterType<IExploreMetadata, Explorer>();
            DependencyInjection.RegisterType<IExtractMetadata, Extractor>();
        }
    }
}