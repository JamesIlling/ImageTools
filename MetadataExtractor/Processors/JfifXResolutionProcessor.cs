namespace MetadataExtractor.Processors
{
    using System;

    public class JfifXResolutionProcessor : ISupportQueries
    {
        public string Query => "/app0/{ushort=2}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.XResolution = Convert.ToDecimal((ushort) property);
            }
        }
    }
}