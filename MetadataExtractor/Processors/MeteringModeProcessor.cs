namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class MeteringModeProcessor : EnumProcessor<MeteringModeEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown metering mode value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }


        public string Query => "/app1/ifd/exif/{ushort=37383}";

        public void Process(Metadata metadata, object property)
        {
            metadata.MeteringMode = Process(property, Log, Error);
        }
    }
}