namespace MetadataExtractor.Processors
{
    public class LensSpecificationProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=42034}";

        public void Process(Metadata metadata, object property)
        {
            var value = (long[]) property;

            if (value.Length == 4)
            {
                metadata.MinFocalLength = ExifHelper.GetSignedRational(value[0]);
                metadata.MaxFocalLength = ExifHelper.GetSignedRational(value[1]);
                metadata.MinFStop = ExifHelper.GetSignedRational(value[2]);
                metadata.MaxFStop = ExifHelper.GetSignedRational(value[3]);
            }
        }
    }
}