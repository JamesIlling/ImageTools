namespace MetadataExtractor.Processors.Jfif
{
    using System;

    public class ThumbnailXProcessor : ISupportQueries
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