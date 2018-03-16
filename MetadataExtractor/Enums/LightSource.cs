namespace MetadataExtractor.Enums
{
    public enum LightSource : ushort
    {
        Unknown = 0,
        Daylight,
        Fluorescent,
        Tungsten,
        Flash,
        Fine = 9,
        Cloudy,
        Shade,
        DaylightFlourencent,
        DaywhiteFluorescent,
        CoolWhiteFluorescent,
        WhiteFluorescent,
        StandardLightA,
        StandardLightB,
        StandardLightC,
        D55,
        D65,
        D75,
        D50,
        IsoStudioTungsten,
        OtherLightSource = 0x255
    }
}