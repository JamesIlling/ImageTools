namespace MetadataExtractor.Enums
{
    public enum CompressionEnum : ushort
    {
        Unknown = 0,
        Uncompressed = 1,
        CCITT1D = 2,
        T4Fax = 3,
        T6Fax = 4,
        Lzw = 5,
        JpegOldStyle = 6,
        Jpeg = 7,
        AdobeDeflate = 8,
        JbigBW = 9,
        JbigColour = 10,
        Next = 32766,
        CCIRLEW = 32771,
        PackBits = 32773,
        Thunderscan = 32809,
        IT8CTPAD = 32895,
        IT8LW = 32896,
        IT8MP = 32897,
        IT8BL = 32898,
        PixarFilm = 32908,
        PixarLog = 32909,
        Deflate = 32946,
        DCS = 32947,
        JBIG = 32661,
        SGILog = 32676,
        SGILog24 = 32677,
        JPEG2000 = 32712,
        NEF = 32713
    }
}