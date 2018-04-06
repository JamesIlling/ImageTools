namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class GainControlProcessor : EnumProcessor<GainControl>, ISupportErrorableQueries
    {
        public string Error => "Unknown gain control value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41991}";

        public void Process(Metadata metadata, object property)
        {
            metadata.GainControl = Process(property, Log, Error);
        }
    }
}