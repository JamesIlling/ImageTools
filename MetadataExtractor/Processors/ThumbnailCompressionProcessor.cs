namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ThumbnailCompressionProcessor : EnumProcessor<Compression>, ISupportErrorableQueries
    {
        public string Error => "Unknown thumbnail compression value:{0:X4}";

        public string Query => "/app1/thumb/{ushort=259}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailCompression = Process(property, Log, Error);
        }
    }
}