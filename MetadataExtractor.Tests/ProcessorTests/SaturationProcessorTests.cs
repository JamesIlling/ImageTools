﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class SaturationProcessorTests : EnumTests<SaturationProcessor, SaturationEnum, ushort>

    {
        public SaturationProcessorTests()
            : base(x => x.Saturation, "/app1/ifd/exif/{ushort=41993}")
        {}
    }
}