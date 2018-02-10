namespace MetadataExtractor.Processors
{
    public class CopyrightProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x8298;

        public void Process(Metadata metadata, ExifProperty property)
        {
            metadata.Copyright = ExifHelper.GetString(property);
        }
    }
}