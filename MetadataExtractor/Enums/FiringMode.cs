namespace MetadataExtractor.Enums
{
    public enum FiringMode : ushort
    {
        Unknown = 0x0000,
        CompulsoryFiring = 0x0008,
        CompulsorySuppression = 0x0010,
        Auto = 0x0018
    }
}