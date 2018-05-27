namespace MetadataExtractor.Processors.Exif
{
    using Enums;
    using Unity.Attributes;

    public class ColourSpaceProcessor : EnumProcessor<ColourSpace>, ISupportErrorableQueries
    {
        public string Error => "Unknown colour space value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=40961}";

        [Dependency]
        public ILog Log { get; set; }


        public void Process(Metadata metadata, object property)
        {
            metadata.ColourSpace = Process(property, Log, Error);
        }
    }
}