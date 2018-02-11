namespace MetadataExtractor.Processors
{
    public class DigitalZoomRatioProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA404;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.DigitalZoomRatio = ExifHelper.GetRational(property);
        }
    }
}