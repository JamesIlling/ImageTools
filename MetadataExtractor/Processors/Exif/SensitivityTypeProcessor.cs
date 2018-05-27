namespace MetadataExtractor.Processors.Exif
{
    using Enums;
    using Unity.Attributes;

    public class SensitivityTypeProcessor : EnumProcessor<SensitivityType>, ISupportErrorableQueries
    {
        public string Error => "Unknown sensitivity type value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=34864}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.SensitivityType = Process(property, Log, Error);
        }
    }
}