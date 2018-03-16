namespace MetadataExtractor.Processors
{
    using System.Text;
    using System.Windows.Media.Imaging;

    public class FlashPixVersionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=40960}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                var value = property as BitmapMetadataBlob;
                if (value != null)
                {
                    metadata.FlashpixVersion = Encoding.ASCII.GetString(value.GetBlobValue());
                }
            }
        }
    }
}