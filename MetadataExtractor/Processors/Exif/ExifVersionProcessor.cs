namespace MetadataExtractor.Processors.Exif
{
    using System.Text;
    using System.Windows.Media.Imaging;

    public class ExifVersionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=36864}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ExifVersion = Encoding.ASCII.GetString(((BitmapMetadataBlob) property).GetBlobValue());
            }
        }
    }
}