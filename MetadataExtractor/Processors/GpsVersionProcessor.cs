namespace MetadataExtractor.Processors
{
    using System;
    using System.Windows.Media.Imaging;

    public class GpsVersionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/gps/{ushort=0}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                var data = property as BitmapMetadataBlob;
                var values = data?.GetBlobValue();
                if (values?.Length == 4)
                {
                    metadata.GpsVersion = new Version(values[0], values[1], values[2], values[3]);
                }
            }
        }
    }
}