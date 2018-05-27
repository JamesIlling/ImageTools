namespace MetadataExtractor.Processors.Exif
{
    using System.Linq;

    public class ChromaticitiesProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=319}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null && property is ulong[] data)
            {
                metadata.Chromaticities = data.Select(x => ExifHelper.GetRational(x)).ToArray();
            }
        }
    }
}