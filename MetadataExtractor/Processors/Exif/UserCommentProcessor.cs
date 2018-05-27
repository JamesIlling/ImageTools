namespace MetadataExtractor.Processors.Exif
{
    public class UserCommentProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=37510}";

        public void Process(Metadata metadata, object property)
        {
            metadata.UserComment = ExifHelper.GetString(property);
        }
    }
}