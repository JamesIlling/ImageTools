using System.Collections.Generic;

namespace MetadataExtractor.Processors
{
    public class ReferenceBlackWhiteProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=532}";

        public void Process(Metadata metadata, object property)
        {
            List<decimal> value = new List<decimal>();
            if (property != null)
            {
                foreach (var item in property as ulong[])
                {
                    value.Add(ExifHelper.GetRational(item).Value);                    
                }
                metadata.ReferenceBlackWhite = value.ToArray();
            }
        }
    }
}