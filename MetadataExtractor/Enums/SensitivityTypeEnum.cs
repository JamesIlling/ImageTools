namespace MetadataExtractor.Enums
{
    public enum SensitivityTypeEnum : ushort
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