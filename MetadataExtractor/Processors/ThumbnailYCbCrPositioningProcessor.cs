namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ThumbnailYCbCrPositioningProcessor : EnumProcessor<YCbCrPositioning>, ISupportErrorableQueries
    {
        public string Error => "Unknown thumbnail y cb cr positioning value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/thumb/{ushort=531}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ThumbnailYCbCrPositioning = Process(property, Log, Error);
        }
    }
}