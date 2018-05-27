namespace MetadataExtractor.Processors.Exif
{
    using System.Windows.Media.Imaging;
    using Enums;
    using Unity.Attributes;

    public class FileSourceProcessor : EnumProcessor<FileSource>, ISupportErrorableQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41728}";
        public string Error => "Unknown file source value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            var value = property as BitmapMetadataBlob;
            if (value != null)
            {
                metadata.FileSource = Process(value.GetBlobValue()[0], Log, Error);
            }
        }
    }
}