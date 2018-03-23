using System;
using System.IO;
using System.Linq;
using CommandLine;
using DependencyFactory;
using ImageTools.Options;
using MetadataExtractor;
using MetadataExtractor.Tests;

namespace ImageTools
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            RegisterDependencies();

            Parser.Default.ParseArguments<ExploreOptions, ExtractOptions,TestOptions>(args)
                .MapResult(
                    (ExploreOptions opts) => Explore(opts),
                    (ExtractOptions opts) => Extract(opts),
                    (TestOptions opts) => ExploreTestData(opts),
                    errs=>false);
        }

        private static bool ExploreTestData(TestOptions opts)
        {
            var explorer = DependencyInjection.Resolve<IExploreMetadata>();
            foreach (var item in TestResources.All())
            {
                var items = explorer.Explore(item.Value, false, true).ToList();

                var maxLength = items.Select(x => x.Type).Max(x => x.Length) + 1;
                     
                File.WriteAllLines(Path.Combine(opts.Folder,item.Value+".txt"),items.Select(x => x.Type.PadRight(maxLength) + ":" + x.Query));
            }
            return true;
        }

        private static bool Extract(ExtractOptions opts)
        {
            var extractor = DependencyInjection.Resolve<IExtractMetadata>();
            var display = DependencyInjection.Resolve<IDisplay>();
            if (File.Exists(opts.File))
            {
                using (var fs = new FileStream(opts.File, FileMode.Open))
                {
                    var item = extractor.ExtractMetadata(fs);
                    display.Display(item);
                    return true;
                }
            }
            return false;
        }

        private static bool Explore(ExploreOptions opts)
        {
            var explorer = DependencyInjection.Resolve<IExploreMetadata>();
            if (File.Exists(opts.File))
            {
                if (Path.GetExtension(opts.File) != ".jpg")
                {
                    Console.WriteLine($"file type {Path.GetExtension(opts.File)} is not supported");
                    return false;
                }

                using (var fs = new FileStream(opts.File, FileMode.Open))
                {
                    var items = explorer.Explore(fs, opts.MapToProcessors, opts.UnknownOnly).ToList();
                    var maxLength = items.Select(x => x.Type).Max(x => x.Length) + 1;
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.Type.PadRight(maxLength) + ":" + item.Query);
                    }
                    return true;
                }
            }
            Console.WriteLine($"Unable to locate file {opts.File}");
            return false;
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