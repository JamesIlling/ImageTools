namespace MetadataExtractor.Processors.Exif
{
    using Enums;
    using Unity.Attributes;

    public class SaturationProcessor : EnumProcessor<Saturation>, ISupportErrorableQueries
    {
        public string Error => "Unknown saturation value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=41993}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.Saturation = Process(property, Log, Error);
        }
    }
}