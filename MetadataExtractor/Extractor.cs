namespace MetadataExtractor
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Unity.Attributes;

    public class Extractor
    {
        [Dependency]
        public ILog Log { get; set; }

        [Dependency]
        public IGetProcessors ProcessorLocator { get; set; }

        public Metadata Extract(Stream image)
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