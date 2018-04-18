namespace MetadataExtractor.Processors
{
    using System;

    public class JfifYResolutionProcessor : ISupportQueries
    {
        public string Query => "/app0/{ushort=3}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.YResolution = Convert.ToDecimal((ushort) property);
            }
        }
    }
}