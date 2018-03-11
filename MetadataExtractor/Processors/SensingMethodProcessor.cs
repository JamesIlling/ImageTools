namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class SensingMethodProcessor : EnumProcessor<SensingMethodEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown sensing method value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=41495}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.SensingMethod = Process(property, Log, Error);
        }
    }
}