namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class CustomRenderingProcessor : EnumProcessor<CustomRenderingEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown custom rendering value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41985}";

        public void Process(Metadata metadata, object property)
        {
            metadata.CustomRendering = Process(property, Log, Error);
        }
    }
}