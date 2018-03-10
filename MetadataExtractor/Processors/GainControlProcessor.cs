namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using Enums;
    using Unity.Attributes;

    public class GainControlProcessor : EnumProcessor<GainControlEnum>, ISupportQueries
    {
        public string Error => "Unknown Gain Control value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public string Query => "/app1/ifd/exif/{ushort=41991}";

        public void Process(Metadata metadata, object property)
        {
            metadata.GainControl = Process(property, Log, Error);
        }
    }
}