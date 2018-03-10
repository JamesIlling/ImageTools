namespace MetadataExtractor.Processors
{
    using Enums;
    using Unity.Attributes;

    public class ColourSpaceProcessor : EnumProcessor<ColourSpaceEnum>, ISupportErrorableQueries
    {
        public string Error => "Unknown Colour Space value:{0:X4}";

        public string Query => "/app1/ifd/exif/{ushort=40961}";

        [Dependency]
        public ILog Log { get; set; }


        public void Process(Metadata metadata, object property)
        {
            metadata.ColourSpace = Process(property, Log, Error);
        }
    }
}