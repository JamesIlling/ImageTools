namespace MetadataExtractor.Processors.Jfif
{
    using System;

    public class ThumbnailYProcessor : ISupportQueries
    {
        public string Query => "/app0/{ushort=5}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.ThumbnailYResolution = Convert.ToDecimal((byte) property);
            }
        }
    }
}