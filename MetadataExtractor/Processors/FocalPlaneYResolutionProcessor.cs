namespace MetadataExtractor.Processors
{
    public class FocalPlaneYResolutionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA20F;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.FocalPlaneYResolution = ExifHelper.GetRational(property);
        }
    }
}