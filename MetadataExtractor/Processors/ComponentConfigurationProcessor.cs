namespace MetadataExtractor.Processors
{
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Enums;
    using Unity.Attributes;

    public class ComponentConfigurationProcessor : EnumProcessor<ComponentConfiguration>, ISupportErrorableQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37121}";

        public string Error => "Unknown component configuration value:{0:X4}";

        [Dependency]
        public ILog Log { get; set; }

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                var blob = property as BitmapMetadataBlob;
                var values = blob?.GetBlobValue();
                if (values?.Length == 4)
                {
                    var data = values.Select(x => Process(x, Log, Error)).ToArray();
                    if (data.All(x => x != null))
                    {
                        metadata.ComponentConfiguration = data.Select(x => x.Value).ToArray();
                    }
                }
            }
        }
    }
}