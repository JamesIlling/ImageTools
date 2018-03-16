namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ThumbnailResolutionUnitProcessor : EnumProcessor<ResolutionUnit>, ISupportErrorableQueries
    {
        public string Error => "Unknown thumbnail resolution unit value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/thumb/{ushort=296}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailResolutionUnit = Process(property, Log, Error);
        }
    }
}