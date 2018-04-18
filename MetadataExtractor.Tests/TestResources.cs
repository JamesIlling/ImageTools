namespace MetadataExtractor.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    [ExcludeFromCodeCoverage]
    public static class TestResources
    {
        private const string LightroomJpegPath = "MetadataExtractor.Tests.Resources.Lightroom.jpg";
        private const string AcdSeeJpegPath = "MetadataExtractor.Tests.Resources.ACDSee.jpg";
        private const string D800EJpegPath = "MetadataExtractor.Tests.Resources.D800e.jpg";
        private const string Eos5dMkIvJpegPath = "MetadataExtractor.Tests.Resources.Eos5DMkIV.jpg";
        private const string LytroJpegPath = "MetadataExtractor.Tests.Resources.Lytro.jpg";

        public static Dictionary<string, Stream> All()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceNames().ToDictionary(x => x, x => assembly.GetManifestResourceStream(x));
        }

        public static Stream LightroomJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(LightroomJpegPath);
        }

        public static Stream AcdSeeJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(AcdSeeJpegPath);
        }

        public static Stream Eos5DMkIVJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(Eos5dMkIvJpegPath);
        }

        public static Stream D800EJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(D800EJpegPath);
        }

        public static Stream LytroJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(LytroJpegPath);
        }
    }
}