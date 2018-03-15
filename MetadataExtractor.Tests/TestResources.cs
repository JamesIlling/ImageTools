namespace MetadataExtractor.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public static class TestResources
    {
        private const string LightroomJpegPath = "MetadataExtractor.Tests.Resources.Lightroom.jpg";
        private const string AcdSeeJpegPath = "MetadataExtractor.Tests.Resources.ACDSee.jpg";
        private const string D800EJpegPath = "MetadataExtractor.Tests.Resources.D800e.jpg";
        private const string Eos5DMkIVPath= "MetadataExtractor.Tests.Resources.Eos5DMkIV.jpg";

        public static List<Stream> All()
        {
            return new List<Stream>{LightroomJpeg(),AcdSeeJpeg(),Eos5DMkIVJpeg(),D800EJpeg()};
        }

        public static Stream LightroomJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetManifestResourceNames();
            return assembly.GetManifestResourceStream(LightroomJpegPath);
        }

        public static Stream AcdSeeJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetManifestResourceNames();
            return assembly.GetManifestResourceStream(AcdSeeJpegPath);
        }

        public static Stream Eos5DMkIVJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetManifestResourceNames();
            return assembly.GetManifestResourceStream(Eos5DMkIVPath);
        }

        public static Stream D800EJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetManifestResourceNames();
            return assembly.GetManifestResourceStream(D800EJpegPath);
        }
    }
}