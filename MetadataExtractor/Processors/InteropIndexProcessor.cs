namespace MetadataExtractor.Processors
{
    public class InteropIndexProcessor : ISupportErrorableQueries
    {
        public string Query => "/app1/ifd/exif/interop/{ushort=1}";
        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                var type = property as string;
                switch (type)
                {
                    case "R03":
                        metadata.Interop = "DCF option File (Adobe RGB)";
                        break;
                    case "R98":
                        metadata.Interop = "DCF basic File (sRGB)";
                        break;
                    case "THM":
                        metadata.Interop = "DCF Thumbnail File";
                        break;
                    default:
                        Log.Warning(string.Format(Error, type));
                        break;
                }
            }
        }

        public string Error => "Unknown interop index value:{0}";
        public ILog Log { get; set; }
    }
}
