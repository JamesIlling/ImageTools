namespace MetadataExtractor.Enums
{
    public enum ColourSpaceEnum : ushort
    {
        Unknown = 0,
        sRGB = 1,
        AdobeRGB = 2,
        WideGamutRGB = 0xFFFD,
        ICCProfile = 0xFFFE,
        Uncalibrated = 0xFFFF
    }
}