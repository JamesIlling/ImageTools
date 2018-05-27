namespace MetadataExtractor.Processors.Jfif
{
    using System;

    public class XResolutionProcessor : ISupportQueries
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