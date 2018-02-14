﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ArtistProcessorTests : StringTests<ArtistProcessor>
    {
        public ArtistProcessorTests()
            : base(0x013B, "Artist")
        {}
    }
}