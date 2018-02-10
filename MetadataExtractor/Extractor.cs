namespace MetadataExtractor
{
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Processors;
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
                    processor.Process(metadata, new ExifProperty(property));
                }
                else
                {
                    Log.Info("Unknown element: Id 0x" + property.Id.ToString("X8"));
                }
            }
            return metadata;
        }
    }
}