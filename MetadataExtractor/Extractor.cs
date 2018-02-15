namespace MetadataExtractor
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Media.Imaging;
    using Unity.Attributes;

    public class Extractor
    {
        [Dependency]
        public IGetProcessors ProcessorLocator { get; set; }

        public static Metadata ExtractFromWindowsImagingComponent(Stream image)
        {
            var dec = new JpegBitmapDecoder(image, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            var frame = dec.Frames[0];
            var bitmapMetadata = (BitmapMetadata) frame.Metadata;

            var processors = GetProcessors();
            var metadata = new Metadata
            {
                Height = frame.PixelHeight,
                Width = frame.PixelWidth
            };
            foreach (var processor in processors)
            {
                var property = bitmapMetadata?.GetQuery(processor.Query);
                processor.Process(metadata, property);
            }

            return metadata;
        }

        private static IEnumerable<ISupportQueries> GetProcessors()
        {
            var rh = new ReflectionHelper();
            var processors = rh.GetAll<ISupportQueries>();
            return processors;
        }
    }
}