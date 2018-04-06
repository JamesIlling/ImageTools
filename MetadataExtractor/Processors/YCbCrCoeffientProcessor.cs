﻿namespace MetadataExtractor.Processors
{
    using System.Linq;

    public class YCbCrCoeffientProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/{ushort=529}";

        public void Process(Metadata metadata, object property)
        {
            if (property != null && property is ulong[] data)
            {
                metadata.YCbCrCoeffients = data.Select(x => ExifHelper.GetRational(x)).ToArray();
            }
        }
    }
}
