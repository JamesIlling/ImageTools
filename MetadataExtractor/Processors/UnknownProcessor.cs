namespace MetadataExtractor.Processors
{
    public  class UnknownProcessor : UnsuportedQuery
    {
        public UnknownProcessor()
            : base("/unknown/{}")
        {
        }
    }
}
