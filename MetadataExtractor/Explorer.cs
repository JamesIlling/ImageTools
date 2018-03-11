namespace MetadataExtractor
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Unity.Attributes;

    public class Explorer : IExploreMetadata
    {
        private static readonly Dictionary<string, string> Replacements = new Dictionary<string, string>
        {
            {"/app1/{ushort=0}", "/app1/ifd"},
            {"/app1/ifd/{ushort=34665}", "/app1/ifd/exif"},
            {"/app1/{ushort=1}", "/app1/thumb"},
            {"/app13/{ushort=0}", "/app13/irb"},
            {"/app13/irb/{ulonglong=61857348781060}", "/app13/irb/8bimiptc"},
            {"/app13/irb/{ulonglong=61857348781037}", "/app13/irb/8bimResInfo"}
        };

        [Dependency]
        public IGetProcessors ProcessorLocator { get; set; }

        public IEnumerable<MetadataItem> GetUnknownElements(Stream file)
        {
            var bitmapMetadata = GetBitmapMetadata(file);
            var properties = new List<MetadataItem>();
            var existing = ProcessorLocator.GetAll<ISupportQueries>().Select(x => x.Query).ToList();
            ProcessBitmapMetadata(bitmapMetadata, existing, properties);
            return properties;
        }

        private static BitmapMetadata GetBitmapMetadata(Stream image)
        {
            var dec = new JpegBitmapDecoder(image, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            var frame = dec.Frames[0];
            var bitmapMetadata = (BitmapMetadata) frame.Metadata;
            return bitmapMetadata;
        }

        private static void ProcessBitmapMetadata(BitmapMetadata bitmapMetadata, ICollection<string> processors,
            ICollection<MetadataItem> missing)
        {
            foreach (var path in bitmapMetadata)
            {
                var item = bitmapMetadata.GetQuery(path);
                if (item is BitmapMetadata)
                {
                    ProcessBitmapMetadata(item as BitmapMetadata, processors, missing);
                }
                else
                {
                    var fullPath = bitmapMetadata.Location + path;

                    fullPath = Replacements.Aggregate(fullPath,
                        (current, replacement) => current.Replace(replacement.Key, replacement.Value));
                    if (!processors.Contains(fullPath))
                    {
                        missing.Add(new MetadataItem(item?.GetType().Name, fullPath));
                    }
                }
            }
        }
    }
}