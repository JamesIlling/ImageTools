namespace MetadataExtractor.Enums
{
    public enum MeteringMode : ushort
    {
        Unknown = 0,
        Average = 1,
        CenterWeightedAverage = 2,
        Spot = 3,
        MultiSpot = 4,
        MultiSegment = 5,
        Patial = 6,
        Other = 255
    }
}