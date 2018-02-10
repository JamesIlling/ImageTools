namespace MetadataExtractor.Tests
{
    using System.IO;
    using System.Reflection;

    public static class TestResources
    {
        private const string TinyJpegResourceName = "MetadataExtractor.Tests.Resources.Lightroom.jpg";

        public static Stream LightroomJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetManifestResourceNames();
            return assembly.GetManifestResourceStream(TinyJpegResourceName);
        }
    }
}