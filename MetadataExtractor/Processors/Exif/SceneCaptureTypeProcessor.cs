namespace MetadataExtractor.Processors.Exif
{
    using Enums;
    using Unity.Attributes;

    public class SceneCaptureTypeProcessor : EnumProcessor<SceneCaptureType>, ISupportErrorableQueries
    {
        public string Error => "Unknown scene capture type value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=41990}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            metadata.SceneCaptureType = Process(property, Log, Error);
        }
    }
}