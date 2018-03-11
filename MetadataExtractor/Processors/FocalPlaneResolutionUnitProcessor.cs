namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class FocalPlaneResolutionUnitProcessor : EnumProcessor<ResolutionUnitEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown focal plane resolution unit value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41488}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalPlaneResolutionUnit = Process(property, Log, Error);
        }
    }
}