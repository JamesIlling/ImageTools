namespace MetadataExtractor
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public class Extractor
    {
        public Extractor()
        {
            Processors = ReflectionHelper.GetAll<IMetaDataElementProcessor>();
        }

        public List<IMetaDataElementProcessor> Processors { get; set; }

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
                var processor = Processors.FirstOrDefault(x => x.Id == property.Id);
                processor?.Process(metadata, new ExifProperty(property));
            }
            return metadata;
        }
    }
}