namespace MetadataExtractor.Processors
{
    public class FocalLengthProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/subifd:{uint=37386}";

        public  void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                metadata.FocalLength = ExifHelper.GetRational(property);
            }
        }
    }
}