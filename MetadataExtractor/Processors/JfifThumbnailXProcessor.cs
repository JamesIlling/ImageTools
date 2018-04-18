namespace MetadataExtractor.Processors
{
    using System;

    public class JfifThumbnailXProcessor : ISupportQueries
    {
        public string Query => "/app0/{ushort=4}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ThumbnailXResolution = Convert.ToDecimal((byte) property);
            }
        }
    }
}