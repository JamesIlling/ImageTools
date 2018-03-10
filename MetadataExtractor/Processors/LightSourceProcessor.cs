namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class LightSourceProcessor : EnumProcessor<LightSourceEnum>, ISupportQueries
    {
        public string Error => "Unknown Lightsource value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=37384}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Lightsource = Process(property, Log, Error);
        }
    }
}