namespace MetadataExtractor.Processors
{
    public class MakersNoteProcessor : UnsuportedQuery
    {
        public MakersNoteProcessor()
            : base("/app1/ifd/exif/{ushort=37500}")
        { }
    }
}