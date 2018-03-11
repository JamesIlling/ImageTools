namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class SharpnessProcessor : EnumProcessor<SharpnessEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown sharpness value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=41994}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.Sharpness = Process(property, Log, Error);
        }
    }
}