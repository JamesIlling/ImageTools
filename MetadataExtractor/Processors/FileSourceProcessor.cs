namespace MetadataExtractor.Processors
{
    internal class FileSourceProcessor : IMetaDataElementProcessor
    {
        public int Id => 0xA300;

        public void Process(Metadata metadata, ExifProperty property)
        {}
    }
}