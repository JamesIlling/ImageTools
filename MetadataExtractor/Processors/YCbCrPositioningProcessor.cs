namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class YCbCrPositioningProcessor : EnumProcessor<YCbCrPositioningEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown y cb cr positioning value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{uint=531}";

        public void Process(Metadata metadata, object property)
        {
            metadata.YCbCrPositioning = Process(property, Log, Error);
        }
    }
}