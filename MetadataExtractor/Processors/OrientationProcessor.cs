namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class OrientationProcessor : EnumProcessor<OrientationEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown Orientation value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/{uint=274}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Orientation = Process(property, Log, Error);
        }
    }
}