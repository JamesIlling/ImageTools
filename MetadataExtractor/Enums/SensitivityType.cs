namespace MetadataExtractor.Enums
{
    public enum SensitivityType : ushort
    {
        Unknown = 0,
        StandardOutputSensitivity,
        RecommendedExposureIndex,
        IsoSpeed,
        StandardOutputSensitivityAndRecommendedExposureIndex,
        StandardOutputSensitivityAndIsoSpeed,
        RecommendedExposureIndexAndIsoSpeed,
        StandardOutputSensitivityRecommendedExposureIndexAndIsoSpeed
    }
}