namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ResolutionUnitProcessor : EnumProcessor<ResolutionUnitEnum>,ISupportErrorableQueries
    {
        public string Error => "Unknown Resolution unit value:{0:X4}";

        public string Query => "/app1/ifd/{ushort=296}";

        [Dependency]
        public ILog Log { get; set; }
        public void Process(Metadata metadata, object property)
        {
            metadata.ResolutionUnit = Process(property, Log, Error);
        }
    }
}