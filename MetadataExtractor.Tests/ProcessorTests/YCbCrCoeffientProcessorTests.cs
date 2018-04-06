﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class YCbCrCoeffientProcessorTests : ArrayOfRationalTests<YCbCrCoeffientProcessor>
    {
        public YCbCrCoeffientProcessorTests()
            : base(x => x.YCbCrCoeffients, "/app1/ifd/{ushort=529}")
        {}
    }
}