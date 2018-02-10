namespace MetadataExtractor.Processors
{
    internal class FocalPlaneXResolutionProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA20E;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.FocalPlaneXResolution = ExifHelper.GetRational(property);
        }
    }
}