namespace MetadataExtractor.Tests
{
    using System.IO;
    using System.Reflection;

    public static class TestResources
    {
        private const string LightroomJpegPath = "MetadataExtractor.Tests.Resources.Lightroom.jpg";
        private const string AcdSeeJpegPath = "MetadataExtractor.Tests.Resources.ACDSee.jpg";
        private const string D800EJpegPath = "MetadataExtractor.Tests.Resources.D800e.jpg";

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

        public static Stream D800EJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetManifestResourceNames();
            return assembly.GetManifestResourceStream(D800EJpegPath);
        }
    }
}