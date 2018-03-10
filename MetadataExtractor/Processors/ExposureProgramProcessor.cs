namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ExposureProgramProcessor : EnumProcessor<ExposureProgramEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown Exposure program value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=34850}";

        public void Process(Metadata metadata, object property)
        {
            metadata.ExposureProgram =  Process(property, Log, Error);
        }
    }
}