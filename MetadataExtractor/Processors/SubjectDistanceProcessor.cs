namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class SubjectDistanceProcessor : EnumProcessor<SubjectDistanceEnum>, ISupportErrorableQueries
    {

        public string Error => "Unknown Subject distance value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=41996}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.SubjectDistance = Process(property, Log, Error);
        }
    }
}