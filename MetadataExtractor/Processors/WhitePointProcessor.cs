
namespace MetadataExtractor.Processors
{
    using System.Linq;

    public class WhitePointProcessor : ISupportQueries
    {

        public string Query => "/app1/ifd/{ushort=318}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null && property is ulong[] data)
            {
                metadata.WhitePoint = data.Select(x => ExifHelper.GetRational(x)).ToArray();
            }
        }
    }
}

