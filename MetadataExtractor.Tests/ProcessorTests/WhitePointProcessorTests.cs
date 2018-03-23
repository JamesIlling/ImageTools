namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class WhitePointProcessorTests : ArrayOfRationalTests<WhitePointProcessor>
    {
        public WhitePointProcessorTests()
            : base(x => x.WhitePoint, "/app1/ifd/{ushort=318}")
        {}
    }
}