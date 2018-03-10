namespace MetadataExtractor.Processors
{
    using System;
    using System.Windows.Media.Imaging;

    internal class YResolutionProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=283}";
        public void Process(Metadata metadata, object property)
        {
            metadata.YResolution = ExifHelper.GetRational(property);
        }
    }
}