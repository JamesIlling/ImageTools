namespace MetadataExtractor.Processors
{
    public class ArtistProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=315}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.Artist = ExifHelper.GetString(property);
            }
        }
    }
}