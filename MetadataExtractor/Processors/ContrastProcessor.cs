namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ContrastProcessor : EnumProcessor<ContrastEnum>, ISupportQueries
    {
        public string Error => "Unknown Contrast value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41992}";

        public void Process(Metadata metadata, object property)
        {
            metadata.Contrast = Process(property, Log, Error);
        }
    }
}