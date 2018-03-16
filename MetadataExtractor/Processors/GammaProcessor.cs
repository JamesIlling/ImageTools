namespace MetadataExtractor.Processors
{
    public class GammaProcessor : ISupportQueries
    {
        public string Query =>"/app1/ifd/exif/{ushort=42240}";
        public void Process(Metadata metadata, object property)
        {
            metadata.Gamma = ExifHelper.GetRational(property);
        }
    }
}
