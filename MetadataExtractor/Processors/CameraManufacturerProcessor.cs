namespace MetadataExtractor.Processors
{
    public class CameraManufacturerProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=271}";


        public void Process(Metadata metadata, object property)
        {
            metadata.CameraManufacturer = ExifHelper.GetString(property);
        }
    }
}