namespace MetadataExtractor.Tests
{
    using System.IO;
    using System.Reflection;

    public static class TestResources
    {
        private const string TinyJpegResourceName = "MetadataExtractor.Tests.Resources.Tiny.jpg";

        public static Stream TinyJpeg()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(TinyJpegResourceName);
        }
    }
}