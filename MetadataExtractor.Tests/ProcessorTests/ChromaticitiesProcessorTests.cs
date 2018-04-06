﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ChromaticitiesProcessorTests : ArrayOfRationalTests<ChromaticitiesProcessor>
    {
        public ChromaticitiesProcessorTests()
            : base(x => x.Chromaticities, "/app1/ifd/{ushort=319}")
        {}
    }
}
