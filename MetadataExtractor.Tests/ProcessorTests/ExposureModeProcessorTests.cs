﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ExposureModeProcessorTests : EnumTests<ExposureModeProcessor, ExposureModeEnum, ushort>
    {
        public ExposureModeProcessorTests()
            : base(x => x.ExposureMode, "/app1/ifd/exif/{ushort=41986}")
        {}
    }
}