using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MetadataExtractor.Tests;

namespace ImageTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using DependencyFactory;
    using MetadataExtractor;

    internal class Program
    {
        private static void Main(string[] args)
        {
            RegisterDependencies();
            /*
            // Extract and display metadata
            var metadata = ExtractMetadataFromFile(@"e:\portfolio\20140326T182844.jpg");
            var displayer = DependencyInjection.Resolve<IDisplay>();
            displayer.Display(metadata);

            Console.WriteLine();
            */

            /*
            // Detect missing processors
            var missing = ExtractorMissingElements(@"e:\portfolio\20140326T182844.jpg");
            Console.WriteLine("Missing:");
            foreach (var item in missing)
            {
                Console.WriteLine(item.Type.PadRight(20, ' ') + ":" + item.Query);
            }*/
            
            var extractor = DependencyInjection.Resolve<IExtractMetadata>();
            var metadata =  extractor.ExtractMetadata(TestResources.AcdSeeJpeg());
            var displayer = DependencyInjection.Resolve<IDisplay>();
            displayer.Display(metadata);

            // Explore Known files
            var explorer = DependencyInjection.Resolve<IExploreMetadata>();
            var acdsee = explorer.GetUnknownElements(TestResources.AcdSeeJpeg());
            File.WriteAllLines(@"e:\acdsee.txt",acdsee.Select(x=> x.Type.PadRight(20, ' ') + ":"+x.Query));
            var d800e = explorer.GetUnknownElements(TestResources.D800EJpeg());
            File.WriteAllLines(@"e:\d800e.txt", d800e.Select(x => x.Type.PadRight(20, ' ') + ":" + x.Query));
            var lr= explorer.GetUnknownElements(TestResources.LightroomJpeg());
            File.WriteAllLines(@"e:\lr.txt", lr.Select(x => x.Type.PadRight(20, ' ') + ":" + x.Query));

        }

        private static void RegisterDependencies()
        {
            DependencyInjection.RegisterType<ILog, ConsoleLog>();
            DependencyInjection.RegisterType<IGetProcessors, ReflectionHelper>();
            DependencyInjection.RegisterType<IDisplay, ConsoleDisplayer>();
            DependencyInjection.RegisterType<IExploreMetadata, Explorer>();
            DependencyInjection.RegisterType<IExtractMetadata, Extractor>();
        }


        private static T FromFile<T>(string path, Func<Stream, T> process) where T : class
        {
            if (File.Exists(path))
            {
                using (var file = File.OpenRead(path))
                {
                    return process(file);
                }
            }
            return null;
        }

        private static Metadata ExtractMetadataFromFile(string path)
        {
            return FromFile(path, file =>
            {
                var extractor = DependencyInjection.Resolve<IExtractMetadata>();
                return extractor.ExtractMetadata(file);
            });
        }

        private static IEnumerable<MetadataItem> ExtractorMissingElements(string path)
        {
            return FromFile(path, file =>
            {
                var explorer = DependencyInjection.Resolve<IExploreMetadata>();
                return explorer.GetUnknownElements(file);
            });
        }
    }
}