namespace MetadataExtractor.Processors
{
    using System.Windows.Media.Imaging;
    using Enums;
    using Unity.Attributes;

    public class SceneTypeProcessor : EnumProcessor<SceneTypeEnum>,ISupportErrorableQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41729}";

        public string Error => "Unknown Scene type value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }
        public void Process(Metadata metadata, object property)
        {
            var value = property as BitmapMetadataBlob;
            if (value != null)
            {
                metadata.ScenceType = Process((ushort)value.GetBlobValue()[0], Log, Error);
            }
        }
    }
}