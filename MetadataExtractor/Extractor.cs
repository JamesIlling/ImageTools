namespace MetadataExtractor
{
    using System.IO;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Unity.Attributes;

    public class Extractor : IExtractMetadata
    {
        [Dependency]
        public IGetProcessors ProcessorLocator { get; set; }

        public Metadata ExtractMetadata(Stream image)
        {
            var bitmapMetadata = GetBitmapMetadata(image);
            var processors = ProcessorLocator.GetAll<ISupportQueries>().OrderBy(x => x.Query);
            var metadata = new Metadata();
            foreach (var processor in processors)
            {
                var property = bitmapMetadata?.GetQuery(processor.Query);
                processor.Process(metadata, property);
            }

            return metadata;
        }

        private static BitmapMetadata GetBitmapMetadata(Stream image)
        {
            var dec = new JpegBitmapDecoder(image, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            var frame = dec.Frames[0];
            var bitmapMetadata = (BitmapMetadata) frame.Metadata;
            return bitmapMetadata;
        }
    }
}