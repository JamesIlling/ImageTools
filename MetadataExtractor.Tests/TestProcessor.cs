namespace MetadataExtractor.Tests
{
    public class TestProcessor : IMetaDataElementProcessor
    {
        public bool Called { get; set; }
        public int Id => 0x110;

        public void Process(Metadata metadata, ExifProperty property)
        {
            Called = true;
        }
    }
}