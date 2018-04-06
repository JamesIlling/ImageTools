namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ExposureProgramProcessor : EnumProcessor<ExposureProgram>, ISupportErrorableQueries
    {
        public string Error => "Unknown exposure program value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=34850}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ExposureProgram = Process(property, Log, Error);
        }
    }
}