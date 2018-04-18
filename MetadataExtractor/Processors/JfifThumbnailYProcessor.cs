namespace MetadataExtractor.Processors
{
    using System;

    public class JfifThumbnailYProcessor : ISupportQueries
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