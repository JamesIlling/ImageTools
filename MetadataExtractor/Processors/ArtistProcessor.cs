namespace MetadataExtractor.Processors
{
    public class ArtistProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x013B;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Artist = ExifHelper.GetString(property);
        }
    }
}