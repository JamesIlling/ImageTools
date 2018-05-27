namespace MetadataExtractor.Processors.Exif
{
    using Enums;
    using Unity.Attributes;

    public class LightSourceProcessor : EnumProcessor<LightSource>, ISupportErrorableQueries
    {
        public string Error => "Unknown light source value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=37384}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Lightsource = Process(property, Log, Error);
        }
    }
}