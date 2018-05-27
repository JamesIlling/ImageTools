namespace MetadataExtractor.Processors.Exif
{
    public class LensManufacturerProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42035}";


        public void Process(Metadata metadata, object property)
        {
            metadata.LensManufacturer = ExifHelper.GetString(property);
        }
    }
}