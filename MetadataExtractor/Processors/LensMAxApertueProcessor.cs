namespace MetadataExtractor.Processors
{
    internal class LensMaxApertueProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9205;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.LensMaxAperture = ExifHelper.GetRational(property);
        }
    }
}