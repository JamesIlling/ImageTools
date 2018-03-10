namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class FocalPlaneResolutionUnitProcessor : EnumProcessor<ResolutionUnitEnum>, ISupportQueries
    {
        public string Error => "Unknown Focal Plane Unit value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41488}";

        public void Process(Metadata metadata, object property)
        {
            metadata.FocalPlaneResolutionUnit = Process(property, Log, Error);
        }
    }
}