namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class WhiteBalanceProcessor : EnumProcessor<WhiteBalanceEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown white balance value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=41987}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.WhiteBalance = Process(property, Log, Error);
        }
    }
}