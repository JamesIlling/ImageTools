namespace MetadataExtractor
{
    using System;
    using Enums;

    public class Metadata
    {
        public ushort? FocalLengthIn35MmFormat { get; set; }
        public DateTime? CaptureTime { get; set; }
        public string CameraManufacturer { get; set; }
        public string CameraModel { get; set; }
        public decimal? ExposureTime { get; set; }
        public ushort? Height { get; set; }
        public ushort? Width { get; set; }
        public string Description { get; set; }
        public decimal? XResolution { get; set; }
        public decimal? YResolution { get; set; }
        public ResolutionUnit? ResolutionUnit { get; set; }
        public string Artist { get; set; }
        public string Copyright { get; set; }
        public string ExifVersion { get; set; }
        public ColourSpace? ColourSpace { get; set; }
        public string Lens { get; set; }
        public string CameraSerialNumber { get; set; }
        public string LensSerialNumber { get; set; }
        public Saturation? Saturation { get; set; }
        public Sharpness? Sharpness { get; set; }
        public string EditingSoftware { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? CreationTime { get; set; }
        public ushort? Iso { get; set; }
        public decimal? ExposureCompensation { get; set; }
        public MeteringMode? MeteringMode { get; set; }
        public ExposureMode? ExposureMode { get; set; }
        public decimal? FNumber { get; set; }
        public ExposureProgram? ExposureProgram { get; set; }
        public SensitivityType? SensitivityType { get; set; }
        public decimal? ShutterSpeedApexValue { get; set; }
        public decimal? ApertureApexValue { get; set; }
        public decimal? LensMaxAperture { get; set; }
        public LightSource? Lightsource { get; set; }
        public decimal? FocalLength { get; set; }
        public SubjectDistance? SubjectDistance { get; set; }
        public decimal? FocalPlaneYResolution { get; set; }
        public decimal? FocalPlaneXResolution { get; set; }
        public ResolutionUnit? FocalPlaneResolutionUnit { get; set; }
        public CustomRendering? CustomRendering { get; set; }
        public WhiteBalance? WhiteBalance { get; set; }
        public decimal? DigitalZoomRatio { get; set; }
        public Contrast? Contrast { get; set; }
        public SensingMethod? SensingMethod { get; set; }
        public SceneCaptureType? SceneCaptureType { get; set; }
        public GainControl? GainControl { get; set; }
        public ColourFilterArray[,] ColourFilterArrayPattern { get; set; }
        public decimal? MinFocalLength { get; set; }
        public decimal? MaxFocalLength { get; set; }
        public decimal? MaxFStop { get; set; }
        public decimal? MinFStop { get; set; }
        public string LensManufacturer { get; set; }
        public bool? FlashFired { get; internal set; }
        public bool? RedEyeReduction { get; set; }
        public bool? FlashFunction { get; set; }
        public StrobeReturn? StrobeReturn { get; set; }
        public FiringMode? FiringMode { get; set; }
        public Orientation? Orientation { get; set; }
        public decimal[] ReferenceBlackWhite { get; set; }
        public YCbCrPositioning? YCbCrPositioning { get; set; }
        public uint? RecommendedExposureIndex { get; set; }
        public string[] Keywords { get; set; }
        public SceneType? SceneType { get; set; }
        public Compression? ThumbnailCompression { get; set; }
        public ResolutionUnit? ThumbnailResolutionUnit { get; set; }
        public decimal? ThumbnailXResolution { get; set; }
        public decimal? ThumbnailYResolution { get; set; }
        public uint? ThumbnailSize { get; set; }
        public uint? ThumbnailOffset { get; set; }
        public FileSource? FileSource { get; set; }
        public string UserComment { get; set; }
        public string Owner { get; set; }
        public decimal? Gamma { get; internal set; }
        public string FlashpixVersion { get; set; }
        public Version GpsVersion { get; set; }
        public ComponentConfiguration[] ComponentConfiguration { get; set; }
        public decimal?[] WhitePoint { get; set; }
        public decimal?[] Chromaticities { get; set; }
    }
}