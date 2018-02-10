namespace MetadataExtractor.Processors
{
    internal class LensSpecificationProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA432;

        public void Process(Metadata metadata, ExifProperty property)
        {
            if (property.Length == 4)
            {
                metadata.MinFocalLength = ExifHelper.GetRational(property, 0);
                metadata.MaxFocalLength = ExifHelper.GetRational(property, 1);
                metadata.MinFStop = ExifHelper.GetRational(property, 2);
                metadata.MaxFStop = ExifHelper.GetRational(property, 3);
            }
        }
    }
}