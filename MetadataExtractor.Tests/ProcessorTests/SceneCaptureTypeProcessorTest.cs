﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public  class SceneCaptureTypeProcessorTest : EnumTests<SceneCaptureTypeProcessor, SceneCaptureTypeEnum,ushort>
    {
        public SceneCaptureTypeProcessorTest()
            : base(metadata => metadata.SceneCaptureType, "/app1/ifd/exif/{ushort=41990}")
        {}
    }
}