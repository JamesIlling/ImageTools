namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ArtistProcessorTests : StringTests<ArtistProcessor>
    {
        public ArtistProcessorTests()
            : base(x => x.Artist, "/app1/ifd/{ushort=315}")
        { }
    }
}