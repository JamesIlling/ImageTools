namespace MetadataExtractor.Processors.Exif
{
    public class MakersNoteProcessor : UnsuportedQuery
    {
        public MakersNoteProcessor()
            : base("/app1/ifd/exif/{ushort=37500}")
        { }
    }
}