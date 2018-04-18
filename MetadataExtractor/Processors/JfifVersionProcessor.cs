namespace MetadataExtractor.Processors
{
    using System;

    public class JfifVersionProcessor : ISupportQueries
    {
        public string Query => "/app0/{ushort=0}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.JfifVersion = string.Join(".", BitConverter.GetBytes((ushort) property));
            }
        }
    }
}