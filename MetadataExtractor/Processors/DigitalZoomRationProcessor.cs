namespace MetadataExtractor.Processors
{
    internal class DigitalZoomRationProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA404;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.DigitalZoom = ExifHelper.GetRational(property);
        }
    }
}