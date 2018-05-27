namespace MetadataExtractor.Processors.Jfif
{
    using System;
    using Enums;
    using Unity.Attributes;

    public class UnitProcessor : EnumProcessor<ResolutionUnit>, ISupportErrorableQueries
    {
        public string Error => "Unknown unit value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app0/{ushort=1}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ResolutionUnit = Process(Convert.ToUInt16(property), Log, Error);
            }
        }
    }
}