namespace MetadataExtractor
{
    using System.Drawing.Imaging;

    public class ExifProperty
    {
        public ExifProperty(PropertyItem item)
        {
            Id = item.Id;
            Length = item.Len;
            Type = item.Type;
            Value = item.Value;
        }

        public ExifProperty()
        {}

        public int Id { get; set; }
        public int Length { get; set; }
        public short Type { get; set; }
        public byte[] Value { get; set; }
    }
}