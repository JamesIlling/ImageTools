namespace MetadataExtractor.Processors
{
    internal class ModifiedDateTimeSubsecondProcessor : IMetaDataElementProcessor

    {
        public int Id => 0x9290;

        public void Process(Metadata metadata, ExifProperty property)
        {
            if (metadata.ModifiedTime != null)
            {
                var ms = double.Parse(ExifHelper.GetString(property));
                metadata.ModifiedTime =
                    metadata.ModifiedTime.Value.AddMilliseconds(ms);
            }
        }
    }
}