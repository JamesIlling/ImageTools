namespace MetadataExtractor.Processors
{
    public class LensManufacturerProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{ushort=42035}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.LensManufacturer = ExifHelper.GetString(property);
            }
        }
    }
}