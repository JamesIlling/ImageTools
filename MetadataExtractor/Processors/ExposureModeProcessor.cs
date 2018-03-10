namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ExposureModeProcessor : EnumProcessor<ExposureModeEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown Exposure mode value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41986}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ExposureMode = Process(property, Log, Error);
        }
    }
}