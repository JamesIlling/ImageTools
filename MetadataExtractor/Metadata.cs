namespace MetadataExtractor
{
    using System;
    using Enums;
    using Processors;

    public class Metadata
    {
        public uint? FocalLengthIn35MmFormat { get; set; }
        public DateTime? CaptureTime { get; set; }
        public string CameraManufacturer { get; set; }
        public string CameraModel { get; set; }
        public decimal? ExposureTime { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Description { get; set; }
        public decimal? XResolution { get; set; }
        public decimal? YResolution { get; set; }
        public ResolutionUnitEnum? ResolutionUnit { get; set; }
        public string Artist { get; set; }
        public string Copyright { get; set; }
        public string ExifVersion { get; set; }
        public ColourSpaceEnum? ColourSpace { get; set; }              
        public string Lens { get; set; }
        public string CameraSerialNumber { get; set; }
        public string LensSerialNumber { get; set; }
        public SaturationEnum? Saturation { get; set; }
        public SharpnessEnum? Sharpness { get; set; }
        public string EditingSoftware { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? CreationTime { get; set; }
        public uint? Iso { get; set; }
        public decimal? ExposureCompensation { get; set; }
        public MeteringModeEnum? MeteringMode { get; set; }
        public ExposureModeEnum? ExposureMode { get; set; }
        public decimal? FNumber { get; set; }
        public ExposureProgramEnum? ExposureProgram { get; set; }
        public SensitivityTypeEnum? SensitivityType { get; set; }
        public decimal? ShutterSpeedApexValue { get; set; }
        public decimal? ApertureApexValue { get; set; }
        public decimal? LensMaxAperture { get; set; }
        public LightSourceEnum? Lightsource { get; set; }
        public decimal? FocalLength { get; set; }
        public SubjectDistanceEnum? SubjectDistance { get; set; }
        public decimal? FocalPlaneYResolution { get; set; }
        public decimal? FocalPlaneXResolution { get; set; }
        public ResolutionUnitEnum? FocalPlaneResolutionUnit { get; set; }
        public CustomRenderingEnum? CustomRendering { get; set; }
        public WhiteBalanceEnum? WhiteBalance { get; set; }
        public decimal? DigitalZoomRatio { get; set; }
        public ContrastEnum? Contrast { get; set; }
        public SensingMethodEnum? SensingMethod { get; set; }
        public SceneCaptureTypeEnum? SceneCaptureType { get; set; }
        public GainControlEnum? GainControl { get; set; }
        public ColourFilterArrayEnum[,] ColourFilterArrayPattern { get; set; }
        public decimal? MinFocalLength { get; set; }
        public decimal? MaxFocalLength { get; set; }
        public decimal? MaxFStop { get; set; }
        public decimal? MinFStop { get; set; }
        public string LensManufacturer { get; set; }
        public bool? FlashFired { get; internal set; }
        public bool? RedEyeReduction { get; set; }
        public bool? FlashFunction { get; set; }
        public StrobeReturnEnum? StrobeReturn { get; set; }
        public FiringModeEnum? FiringMode { get; set; }
        public OrientationEnum? Orientation { get; set; }
        public decimal? ReferenceBlackWhite { get; set; }
        public YCbCrPositioningEnum? YCbCrPositioning { get; set; }
        public uint? RecommendedExposureIndex { get; set; }
        public byte[] IccProfile { get; set; }
        public string[] Keywords { get; set; }
        public SceneTypeEnum? ScenceType { get; set; }
        public CompressionEnum? ThumbnailCompression { get; set; }
        public ResolutionUnitEnum? ThumbnailResolutionUnit { get; set; }
        public decimal? ThumbnailXResolution { get; set; }
        public decimal? ThumbnailYResolution { get; set; }
        public uint? ThumbnailSize { get; set; }
        public uint? ThumbnailOffset { get; set; }
        public FileSourceEnum? FileSource { get; set; }
    }
}