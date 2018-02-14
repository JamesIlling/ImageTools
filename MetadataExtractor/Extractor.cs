namespace MetadataExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Processors;
    using Unity.Attributes;

    public class Extractor
    {
        [Dependency]
        public ILog Log { get; set; }

        [Dependency]
        public IGetProcessors ProcessorLocator { get; set; }

        public static Metadata ExtractFromWindowsImagingComponent(Stream image)
        {
            var bitmapMetadata = GetBitmapMetadata(image);
            var processors = GetProcessors();
            var metadata = new Metadata();
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

        private static BitmapMetadata GetBitmapMetadata(Stream image)
        {
            var dec = new JpegBitmapDecoder(image, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            var frame = dec.Frames[0];
            var bitmapMetadata = (BitmapMetadata) frame.Metadata;
            return bitmapMetadata;
        }

        public Metadata ExtractFromImageProperties(Stream image)
        {
            var bitmap = new Bitmap(image);
            var metadata = new Metadata
            {
                Height = bitmap.Height,
                Width = bitmap.Width
            };

            var properties = bitmap.PropertyItems;

            foreach (var property in properties)
            {
                var processor = ProcessorLocator.GetAll().FirstOrDefault(x => x.Id == property.Id);
                if (processor != null)
                {
                    try
                    {
                        processor.Process(metadata, new ExifProperty(property));
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }
                }
                else
                {
                    Log.Warning("Unknown element: Id 0x" + property.Id.ToString("X8"));
                }
            }
            return metadata;
        }
    }
}