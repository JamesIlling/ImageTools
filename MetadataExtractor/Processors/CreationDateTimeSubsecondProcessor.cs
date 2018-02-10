namespace MetadataExtractor.Processors
{
    internal class CreationDateTimeSubsecondProcessor : IMetaDataElementProcessor
    {
        public int Id => 0x9292;

        public void Process(Metadata metadata, ExifProperty property)
        {
            if (metadata.CreationTime != null)
            {
                var ms = double.Parse(ExifHelper.GetString(property));
                metadata.CreationTime =
                    metadata.CreationTime.Value.AddMilliseconds(ms);
            }
        }
    }
}